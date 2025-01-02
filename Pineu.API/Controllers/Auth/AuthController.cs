using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Pineu.API.Constants;
using Pineu.API.DTOs.Auth;
using Pineu.API.DTOs.Auth.Permissions;
using Pineu.Application.Abstractions.Pools;
using Pineu.Application.Abstractions.Sms;
using Pineu.Application.MainDomain.Profiles.Commands;
using Pineu.Persistence.Constants.Enums;
using Serilog;
using Shared.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Pineu.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, ISmsPool smsPool, ISmsPanel smsPanel, ISender sender) : ControllerBase
    {
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!await ValidateUser(request.Username, request.Password))
            {
                return NotFound(new
                {
                    Message = "User not found"
                });
            }

            var user = await userManager.FindByNameAsync(request.Username);
            if (user == null) return NotFound(new
            {
                Message = "User not found"
            });
            //if (!user.IsActive) return BadRequest(new {
            //    Message = "User not active"
            //});

            Log.Logger.Information("User {username} Logged in", user.UserName);

            return Accepted(new
            {
                Token = await CreateToken(user),
            });
        }

        [HttpPost, Route("SendSms")]
        public async Task<IActionResult> SendSms([FromBody] RegisterOrLoginRequest request)
        {
            var apiKey = Environment.GetEnvironmentVariable("SmsPanelApiKey");
            var templateId = Environment.GetEnvironmentVariable("SmsPanelTemplateIdSendCode");
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(templateId))
                return BadRequest(new
                {
                    Message = "سرویس پیامکی به صورت موقت از دسترس خارج است. لطفا بعداً اقدام کنید."
                });
#if DEBUG
            if (request.PhoneNumber == "01234567410")
                return Ok(new
                {
                    TimeLength = 120,
                    RemainingTime = 120,
                    //Code = code
                });
#endif
            if (!request.PhoneNumber.StartsWith("09") || request.PhoneNumber.Length != 11)
                return BadRequest(new
                {
                    Message = "الگو شمارۀ موبایل وارد شده اشتباه است"
                });

            var previousCode = await smsPool.GetCode(request.PhoneNumber);
            var previousDate = await smsPool.GetDate(request.PhoneNumber);

            if (previousCode.HasValue && previousDate.HasValue)
            {
                var remainingTime = (previousDate.Value - DateTime.Now.AddSeconds(-120)).TotalSeconds;
                if (remainingTime > 0) return Ok(new
                {
                    TimeLength = 120,
                    RemainingTime = (int)remainingTime
                });
            }

            if (previousCode.HasValue) await smsPool.RemoveCode(request.PhoneNumber);
            if (previousDate.HasValue) await smsPool.RemoveDate(request.PhoneNumber);

            Random random = new();
            int code = random.Next(100000, 999999);

            if (!await smsPool.AddCode(request.PhoneNumber, code))
                return BadRequest(new
                {
                    Message = "لطفا دوباره تلاش کنید"
                });
            var dateTime = DateTime.Now;
            if (!await smsPool.AddDate(request.PhoneNumber, dateTime))
                return BadRequest(new
                {
                    Message = "لطفا دوباره تلاش کنید"
                });

            await smsPanel.SendSms(request.PhoneNumber, code, apiKey, Convert.ToInt32(templateId));
            return Ok(new
            {
                TimeLength = 120,
                RemainingTime = 120,
                Code = code
            });
        }

        [HttpPost, Route("ValidateCode")]
        public async Task<IActionResult> ValidateCode([FromBody] ValidateCodeRequest request, CancellationToken cancellationToken)
        {
#if DEBUG
            if (request.PhoneNumber == "01234567410" && request.Code == 654321)
            {
                var defaultUser = await userManager.FindByNameAsync(request.PhoneNumber);
                return Ok(new
                {
                    Token = await CreateToken(defaultUser)
                });
            }
#endif
            if (!request.PhoneNumber.StartsWith("09") || request.PhoneNumber.Length != 11)
                return BadRequest(new
                {
                    Message = "الگو شمارۀ موبایل وارد شده اشتباه است"
                });

            var code = await smsPool.GetCode(request.PhoneNumber);
            var date = await smsPool.GetDate(request.PhoneNumber);
            if (code != request.Code) return BadRequest(new
            {
                Message = "کد اشتباه است"
            });
            if (date.HasValue && date.Value.AddMinutes(2) < DateTime.Now)
                return BadRequest(new
                {
                    Message = "کد منقضی شده است"
                });

            var user = await userManager.FindByNameAsync(request.PhoneNumber);
            var newPassword = Guid.NewGuid().ToString();
            if (user == null)
            {

                user = new User
                {
                    UserName = request.PhoneNumber,
                    PhoneNumber = request.PhoneNumber,
                    PhoneNumberConfirmed = true,
                    IsActive = true
                };

                newPassword = Guid.NewGuid().ToString()[..8];
                var res = await userManager.CreateAsync(user, newPassword);
                if (!res.Succeeded)
                    return BadRequest(res.Errors.First().Description);
                await sender.Send(new UpsertProfileCommand(null, null, null, null, null,request.PhoneNumber, null, "Completed", user.Id), cancellationToken);
            }
            await smsPool.RemoveCode(request.PhoneNumber);
            await smsPool.RemoveDate(request.PhoneNumber);
            return Ok(new
            {
                Token = await CreateToken(user),
                passwoed = newPassword
            });
        }

        [HttpPut, Route("ChangePhoneNumber"), Authorize]
        public async Task<IActionResult> ChangePhoneNumber([FromBody] ValidateCodeRequest request, CancellationToken cancellationToken)
        {
            if (!request.PhoneNumber.StartsWith("09") && request.PhoneNumber.Length != 11)
                return BadRequest(new
                {
                    Message = "الگو شمارۀ موبایل وارد شده اشتباه است"
                });

            var code = await smsPool.GetCode(request.PhoneNumber);
            if (code != request.Code) return BadRequest(new
            {
                Message = "کد اشتباه است"
            });

            var userId = HttpContext.User.Identity.Name;
            var user = await userManager.FindByIdAsync(userId!);
            if (user == null) return BadRequest();

            user.UserName = request.PhoneNumber;
            user.PhoneNumber = request.PhoneNumber;
            var res = await userManager.UpdateAsync(user);

            if (!res.Succeeded) return BadRequest(res.Errors);

            return Ok(new
            {
                Token = await CreateToken(user)
            });
        }

        [HttpGet, Route("me"), Authorize]
        public async Task<IActionResult> Me()
        {
            var username = HttpContext.User.Identity.Name;
            if (!await ValidateUser(username))
            {
                return Unauthorized();
            }

            var user = await userManager.FindByNameAsync(username);
            if (user == null) return NotFound();
            if (user.RemovedAt != null) return Forbid();

            return Ok(new
            {
                Token = await CreateToken(user),
            });
        }


        //[HttpPut, Route("change-password"), Authorize]
        //public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        //{
        //    var username = HttpContext.User.Identity.Name;
        //    if (!await ValidateUser(username, request.OldPassword))
        //    {
        //        return Unauthorized();
        //    }

        //    var user = await userManager.FindByNameAsync(username);
        //    if (user == null) return Unauthorized();

        //    var res = await userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        //    if (!res.Succeeded)
        //    {
        //        return BadRequest(res.Errors);
        //    }

        //    Log.Logger.Information($"User {user.FirstName} {user.LastName} Changed their password");

        //    return Ok();
        //}

        private ClaimsPrincipal GetClaimsFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtConfigs.JwtKey);
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };
            try
            {
                var claimUserValue = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                if (validatedToken.ValidTo > DateTime.UtcNow)
                    return null;
                return claimUserValue;
            }
            catch
            {
                return null;
            }
        }

        private async Task<string> CreateToken(User user)
        {
            var signingCredential = GetSigningCredential();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredential, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<bool> ValidateUser(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);
            return user != null && await userManager.CheckPasswordAsync(user, password);
        }

        private async Task<bool> ValidateUser(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            return user != null;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredential, List<Claim> claims)
        {
            var expireTime = DateTime.Now.AddDays(Convert.ToDouble(JwtConfigs.JwtExpire));

            var token = new JwtSecurityToken(
                issuer: JwtConfigs.JwtIssuer,
                claims: claims,
                expires: expireTime,
                signingCredentials: signingCredential
            );

            return token;
        }

        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            var permissionClaims = await CreatePermissionClaims(user);
            foreach (var claim in permissionClaims)
            {
                claims.Add(new Claim(claim, ""));
            }

            return claims;
        }

        private async Task<IList<string>> CreatePermissionClaims(User user)
        {
            var roleNames = await userManager.GetRolesAsync(user);
            var permissionClaims = new List<string>();

            foreach (var roleName in roleNames)
            {
                var rolePermissionClaims = await GetRolePermissions(roleName);

                foreach (var (name, policies) in rolePermissionClaims)
                {
                    permissionClaims.AddRange(policies.Select(policy => Role.MakePolicy(name, policy)).ToList());
                }
            }

            return permissionClaims;
        }

        private SigningCredentials GetSigningCredential()
        {
            var key = JwtConfigs.JwtKey;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<string>> GetPermissionsJson(IList<string> userRoles)
        {
            var res = new List<string>();

            foreach (var roleName in userRoles)
            {
                var permissions = await GetRolePermissions(roleName);

                foreach (PermissionNames name in Enum.GetValues(typeof(PermissionNames)))
                {
                    if (permissions.TryGetValue(name, out var policies))
                    {
                        foreach (var policy in policies)
                        {
                            if (!res.Contains($"{name}{Role.PermissionClaimSeparator}{policy}"))
                                res.Add($"{name}{Role.PermissionClaimSeparator}{policy}");
                        }
                    }
                }
            }
            return res;
        }

        private async Task<Dictionary<PermissionNames, List<Policies>>> GetRolePermissions(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            var claims = await roleManager.GetClaimsAsync(role);
            var a = claims
                .GroupBy(
                    c => EnumExtensions.Parse<PermissionNames>(c.Type.Split(Role.PermissionClaimSeparator)[0]),
                    c => EnumExtensions.Parse<Policies>(c.Type.Split(Role.PermissionClaimSeparator)[1])
                )
                .ToDictionary(c => c.Key, c => c.ToList())!;
            return a;
        }
    }
}
