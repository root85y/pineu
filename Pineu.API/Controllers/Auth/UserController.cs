//using Pineu.API.DTOs.Auth.Users;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Pineu.Persistence.AuthEntities;
//using Pineu.API.DTOs.Primitives;

//namespace Pineu.API.Controllers.Auth
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController(
//        RoleManager<Role> roleManager,
//        UserManager<User> userManager)
//        : ControllerBase
//    {
//        [HttpPost, Authorize("0:0")]
//        public async Task<IActionResult> CreateUser([FromBody] AddUserRequest request)
//        {
//            if (await userManager.FindByNameAsync(request.Username) != null)
//                return BadRequest(new
//                {
//                    Message = "This username is already taken"
//                });

//            var user = new User
//            {
//                UserName = request.Username,
//                FirstName = request.FirstName,
//                LastName = request.LastName,
//                IsActive = true
//            };

//            var newPassword = Guid.NewGuid().ToString()[..8];
//            var res = await userManager.CreateAsync(user, newPassword);
//            if (!res.Succeeded)
//                return BadRequest(res.Errors.First().Description);

//            return Ok(new
//            {
//                Password = newPassword
//            });
//        }

//        [HttpGet, Authorize("0:1")]
//        public async Task<IActionResult> GetUser([FromQuery] Guid Id)
//        {
//            var user = await userManager.FindByIdAsync(Id.ToString());
//            if (user == null) return NotFound(new
//            {
//                Message = "User not found"
//            });
//            var roleNames = await userManager.GetRolesAsync(user);
//            List<Guid> roles = [];

//            foreach (var item in roleNames)
//            {
//                var role = await roleManager.FindByNameAsync(item);
//                if (role != null)
//                    roles.Add(role.Id);
//            }

//            return Ok(new
//            {
//                user.Id,
//                user.FirstName,
//                user.LastName,
//                user.UserName,
//                user.IsActive,
//                roles
//            });
//        }

//        [HttpGet, Route("All"), Authorize("0:1")]
//        public IActionResult GetAll([FromQuery] string? search, [FromQuery] PaginationRequest pagination)
//        {
//            var users = userManager.Users.Where(u => u.UserName != "admin");

//            if (!string.IsNullOrWhiteSpace(search))
//                users = users.Where(u =>
//                (u.UserName != null && u.UserName.Contains(search)) ||
//                (u.FirstName != null && u.FirstName.Contains(search)) ||
//                (u.LastName.Contains(search)));

//            if (pagination.Page.HasValue && pagination.PageSize.HasValue)
//                users = users.Skip((pagination.Page.Value - 1) * pagination.PageSize.Value).Take(pagination.PageSize.Value);

//            var list = users.Select(u => new GetUserResponse(u.Id, u.FirstName, u.LastName, u.UserName!, u.IsActive))
//                .ToList();
//            return Ok(new
//            {
//                list,
//                list.Count
//            });
//        }

//        [HttpPut, Authorize("0:2")]
//        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] AddUserRequest request)
//        {
//            var user = await userManager.FindByIdAsync(id.ToString());
//            if (user == null) return NotFound(new
//            {
//                Message = "User not found"
//            });

//            if (await userManager.FindByNameAsync(request.Username) != null && user.UserName != request.Username)
//                return BadRequest(new
//                {
//                    Message = "This username is already taken"
//                });

//            user.FirstName = request.FirstName;
//            user.LastName = request.LastName;
//            user.UserName = request.Username;

//            var res = await userManager.UpdateAsync(user);
//            if (!res.Succeeded)
//                return BadRequest(res.Errors.First().Description);

//            return Ok();
//        }

//        [HttpPut, Route("Activate"), Authorize("0:2")]
//        public async Task<IActionResult> ToggleUserActivation([FromQuery] Guid id)
//        {
//            var user = await userManager.FindByIdAsync(id.ToString());
//            if (user == null) return NotFound(new
//            {
//                Message = "User not found"
//            });

//            user.IsActive = !user.IsActive;
//            var res = await userManager.UpdateAsync(user);

//            if (!res.Succeeded)
//                return BadRequest(res.Errors.First().Description);

//            return Ok();
//        }

//        [HttpPut, Route("Roles"), Authorize("0:4")]
//        public async Task<IActionResult> UpdateRoles([FromQuery] Guid id, [FromBody] EditRoleRequest request)
//        {
//            var user = await userManager.FindByIdAsync(id.ToString());
//            if (user == null) return NotFound(new
//            {
//                Message = "User not found"
//            });

//            var previousRoles = await userManager.GetRolesAsync(user);
//            List<string> rolesToRemove = [];
//            List<string> rolesToAdd = [];

//            foreach (var item in previousRoles)
//            {
//                var role = await roleManager.FindByNameAsync(item);
//                if (role != null && !request.Roles.Contains(role.Id))
//                    rolesToRemove.Add(item);
//            }

//            foreach (var item in request.Roles)
//            {
//                var role = await roleManager.FindByIdAsync(item.ToString());
//                if (role != null && !previousRoles.Any(r => r == role.Name))
//                    rolesToAdd.Add(role.Name!);
//            }

//            var res = await userManager.RemoveFromRolesAsync(user!, rolesToRemove);
//            var result = await userManager.AddToRolesAsync(user!, rolesToAdd!);
//            return Ok();
//        }

//        [HttpPut, Route("ResetPassword"), Authorize(policy: "0:6")]
//        public async Task<IActionResult> ResetPassword([FromQuery] Guid id)
//        {
//            var user = await userManager.FindByIdAsync(id.ToString());
//            //var user = await userManager.FindByNameAsync(request.Username);
//            if (user == null) return NotFound(new
//            {
//                Message = "User Not Found"
//            });

//            var token = await userManager.GeneratePasswordResetTokenAsync(user);
//            var newPassword = Guid.NewGuid().ToString()[..8];
//            var res = await userManager.ResetPasswordAsync(user, token, newPassword);
//            if (!res.Succeeded)
//                return BadRequest(res.Errors.First().Description);

//            return Ok(new
//            {
//                Password = newPassword
//            });
//        }
//    }
//}
