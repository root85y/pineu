//using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pineu.API.Constants;
using Pineu.API.DTOs.Auth;
using Pineu.API.DTOs.Auth.Permissions;
using Pineu.Application.Abstractions.Pools;
using Pineu.Application.Abstractions.Sms;
using Pineu.Application.MainDomain.Profiles.Commands;
using Pineu.Domain.Entities.MainDomain;
using Pineu.Persistence.Constants.Enums;
using Serilog;
using Shared.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pineu.API.Controllers.Auth {
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class DoctorAuthController(UserManager<User> userManager, RoleManager<Role> roleManager, ISmsPool smsPool, ISmsPanel smsPanel, ISender sender) : ControllerBase {
        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request) {

            var (isValid, message) = await ValidateUserRegister(request.NationalCode, request.MedicalSystemCode, request.PhoneNumber);

            if (!isValid)
                return NotFound(new {
                    Message = message
                });


            Log.Logger.Information("Doctor {username} Register in", request.PhoneNumber);

            var (IsSuccess, Meessage, code) = await SendSms(new RegisterOrLoginRequest(request.PhoneNumber));
            if (!IsSuccess)
                return NotFound(new {
                    Message = message
                });

            return Accepted(new {
                Message = Meessage,
                Code = code,
                National_Code = request.NationalCode,
                Medical_SystemCode = request.MedicalSystemCode,
                Phone_Number = request.PhoneNumber
            });
        }

        [HttpPost, Route("ValidateCode")]
        public async Task<IActionResult> ValidateCode([FromBody] ValidateCodeRequest request) {
            if (!request.PhoneNumber.StartsWith("09") || request.PhoneNumber.Length != 11) return BadRequest(new {
                Message = "الگو شمارۀ موبایل وارد شده اشتباه است"
            });

            var code = await smsPool.GetCode(request.PhoneNumber);
            var date = await smsPool.GetDate(request.PhoneNumber);
            if (code != request.Code) return BadRequest(new {
                Message = "کد اشتباه است"
            });
            if (date.HasValue && date.Value.AddMinutes(2) < DateTime.Now) return BadRequest(new {
                Message = "کد منقضی شده است"
            });

            await smsPool.RemoveCode(request.PhoneNumber);
            await smsPool.RemoveDate(request.PhoneNumber);

            return Ok(new {
                Message = "با موفقیت شماره موبایل شما تایید شد"

            });
        }

        [HttpPost, Route("ConfirmPassword")]
        public async Task<IActionResult> ConfirmPassword([FromBody] RegisterRequest request, CancellationToken cancellationToken) {
            if (string.IsNullOrEmpty(request.Password) || request.Password.Length < 8) return BadRequest(new {
                Message = "پسورد باید از 8 کارکتر بیشتر باشد"
            });
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);

            if (user != null) {
                var res = await userManager.DeleteAsync(user);

                user = new User {
                    UserName = request.MedicalSystemCode,
                    PhoneNumber = request.PhoneNumber,
                    PhoneNumberConfirmed = true,
                    IsActive = true
                };

                var ress = await userManager.CreateAsync(user, request.Password);
                if (!ress.Succeeded)
                    return BadRequest(res.Errors.First().Description);

                return Ok(new {
                    Message = "دکتر با موفقیت ذخیره شد",
                });
            }
            else {
                user = new User {
                    UserName = request.MedicalSystemCode,
                    PhoneNumber = request.PhoneNumber,
                    PhoneNumberConfirmed = true,
                    IsActive = true
                };

                var res = await userManager.CreateAsync(user, request.Password);

                if (!res.Succeeded)
                    return BadRequest(res.Errors.First().Description);


                var DoctorObj = Doctor.Create(
                    user.Id,
                    null,
                    null,
                    request.PhoneNumber,
                    request.NationalCode,
                    request.MedicalSystemCode,
                    null,
                    null,
                    null
                    );

                await sender.Send(new UpsertDoctorCommand(DoctorObj), cancellationToken);

                return Ok(new {
                    Message = "دکتر با موفقیت ذخیره شد",
                });
            }
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request) {
            var (isValid, message) = await ValidateUserLogin(request.Username, request.Password);

            if (!isValid) {
                return NotFound(new {
                    Message = message
                });
            }

            //var user = await userManager.FindByNameAsync(request.Username);
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.Username);

            if (user == null) return NotFound(new {
                Message = "User not found"
            });
            if (!user.IsActive) return BadRequest(new {
                Message = "User not active"
            });

            var passwordValid = await userManager.CheckPasswordAsync(user.Password, request.Password);
            if (!passwordValid) {
                return BadRequest(new {
                    Message = "Invalid password"
                });
            }


            Log.Logger.Information("Doctor {username} Logged in", user.UserName);

            return Accepted(new {
                Token = await CreateToken(user),
                User = user,
            });
        }

        [HttpPost, Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request) {
            var (isValid, message) = await ValidateUserForgotPassword(request.PhoneNumber);

            if (!isValid) {
                return NotFound(new {
                    Message = message
                });
            }

            var user = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            //var user = await userManager.FindByNameAsync(request.PhoneNumber);
            if (user == null) return NotFound(new {
                Message = "User not found"
            });
            if (!user.IsActive) return BadRequest(new {
                Message = "User not active"
            });


            var (IsSuccess, Meessage, code) = await SendSms(new RegisterOrLoginRequest(request.PhoneNumber));
            if (!IsSuccess) {
                return NotFound(new {
                    Message = message
                });
            }
            Log.Logger.Information("Doctor {username} Password has been clear in", user.UserName);
            return Accepted(new {
                Message = Meessage,
                Code = code,
                phoneNumber = request.PhoneNumber,
            });
        }

        #region back
        private async Task<string> CreateToken(User user = null) {
            if (user == null) {
                var signingCredential = GetSigningCredential();
                var tokenOptions = GenerateTokenOptions(signingCredential);

                return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            }
            else {
                var signingCredential = GetSigningCredential();
                var claims = await GetClaims(user);
                var tokenOptions = GenerateTokenOptions(signingCredential, claims);

                return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            }
        }

        private static async Task<(bool isValid, string message)> ValidateUserRegister(string NationalCode, string MedicalSystemCode, string PhoneNumber) {

            //var nationalCode = await userManager.FindByNameAsync(NationalCode);
            //if (nationalCode != null) return (false, "This national code already exists.");

            if (string.IsNullOrEmpty(NationalCode)) return (false, "National code is required.");
            if (NationalCode.Length != 10) return (false, "National code must be 10 characters long.");

            if (string.IsNullOrEmpty(MedicalSystemCode)) return (false, "Medical system code is required.");

            if (string.IsNullOrEmpty(PhoneNumber)) return (false, "Phone Number is required.");
            if (PhoneNumber.Length != 11) return (false, "Phone Number must be 11 characters long.");
            //var phoneNumber = await userManager.FindByNameAsync(PhoneNumber);
            //if (phoneNumber != null) return (false, "This national code already exists.");

            else return (true, "Validation successful.");
        }

        private static async Task<(bool isValid, string message)> ValidateUserLogin(string MedicalSystemCode, string Password) {

            if (string.IsNullOrEmpty(MedicalSystemCode)) return (false, "Medical system code is required.");

            if (string.IsNullOrEmpty(Password)) return (false, "Password is required.");
            if (Password.Length < 8) return (false, "Password must be more then 8 characters long.");
            //var phoneNumber = await userManager.FindByNameAsync(PhoneNumber);
            //if (phoneNumber != null) return (false, "This national code already exists.");

            else return (true, "Validation successful.");
        }

        private static async Task<(bool isValid, string message)> ValidateUserForgotPassword(string Password) {


            if (string.IsNullOrEmpty(Password)) return (false, "Medical_System_Code is required.");
            if (Password.Length < 8) return (false, "Medical_System_Code must be more then 8 characters long.");

            else return (true, "Validation successful.");
        }

        private async Task<(bool IsSuccess, string? Message, int? Code)> SendSms([FromBody] RegisterOrLoginRequest request) {
            var apiKey = Environment.GetEnvironmentVariable("SmsPanelApiKey");
            var templateId = Environment.GetEnvironmentVariable("SmsPanelTemplateIdSendCode");
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(templateId))
                return (false, "سرویس پیامکی به صورت موقت از دسترس خارج است. لطفا بعداً اقدام کنید.", null);

            if (!request.PhoneNumber.StartsWith("09") || request.PhoneNumber.Length != 11)
                return (false, "الگو شمارۀ موبایل وارد شده اشتباه است", null);

            var previousCode = await smsPool.GetCode(request.PhoneNumber);
            var previousDate = await smsPool.GetDate(request.PhoneNumber);

            if (previousCode.HasValue) await smsPool.RemoveCode(request.PhoneNumber);
            if (previousDate.HasValue) await smsPool.RemoveDate(request.PhoneNumber);

            Random random = new();
            int code = random.Next(100000, 999999);

            if (!await smsPool.AddCode(request.PhoneNumber, code))
                return (false, "لطفا دوباره تلاش کنید", null);
            var dateTime = DateTime.Now;
            if (!await smsPool.AddDate(request.PhoneNumber, dateTime))
                return (false, "لطفا دوباره تلاش کنید", null);

            await smsPanel.SendSms(request.PhoneNumber, code, apiKey, Convert.ToInt32(templateId));
            return (true, "با موفقیت ارسال شد", code);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredential, List<Claim> claims = null) {
            if (claims != null) {
                var expireTime = DateTime.Now.AddDays(Convert.ToDouble(JwtConfigs.JwtExpire));

                var token = new JwtSecurityToken(
                    issuer: JwtConfigs.JwtIssuer,
                    claims: claims,
                    expires: expireTime,
                    signingCredentials: signingCredential
                );

                return token;
            }
            else {
                var expireTime = DateTime.Now.AddDays(Convert.ToDouble(JwtConfigs.JwtExpire));

                var token = new JwtSecurityToken(
                    issuer: JwtConfigs.JwtIssuer,
                    expires: expireTime,
                    signingCredentials: signingCredential
                );

                return token;
            }
        }

        private async Task<List<Claim>> GetClaims(User user) {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            var permissionClaims = await CreatePermissionClaims(user);
            foreach (var claim in permissionClaims) {
                claims.Add(new Claim(claim, ""));
            }

            return claims;
        }

        private async Task<IList<string>> CreatePermissionClaims(User user) {
            var roleNames = await userManager.GetRolesAsync(user);
            var permissionClaims = new List<string>();

            foreach (var roleName in roleNames) {
                var rolePermissionClaims = await GetRolePermissions(roleName);

                foreach (var (name, policies) in rolePermissionClaims) {
                    permissionClaims.AddRange(policies.Select(policy => Role.MakePolicy(name, policy)).ToList());
                }
            }

            return permissionClaims;
        }

        private SigningCredentials GetSigningCredential() {
            var key = JwtConfigs.JwtKey;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<Dictionary<PermissionNames, List<Policies>>> GetRolePermissions(string roleName) {
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
        #endregion
    }
}
