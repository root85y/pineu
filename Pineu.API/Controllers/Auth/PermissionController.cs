//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Pineu.API.DTOs.Auth.Permissions;
//using Shared.Helpers;
//using Pineu.Persistence.AuthEntities;
//using Pineu.Persistence.Constants.Enums;

//namespace Pineu.API.Controllers.Auth
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PermissionController(UserManager<User> userManager, RoleManager<Role> roleManager) 
//        : ControllerBase
//    {
//        [HttpGet, Authorize("1:1")]
//        public async Task<IActionResult> GetAll()
//        {
//            var user = await userManager.FindByNameAsync("admin");

//            var userRoles = await userManager.GetRolesAsync(user);

//            var res = await GetAllPermissionsAsync(userRoles);

//            return Ok(res);
//        }

//        private async Task<IList<GetPermissionsResponse>> GetAllPermissionsAsync(IList<string> userRoles)
//        {
//            var res = new List<GetPermissionsResponse>();
//            foreach (var role in userRoles)
//            {
//                var permissions = await GetRolePermissionClaims(role);

//                foreach (PermissionNames name in Enum.GetValues(typeof(PermissionNames)))
//                {
//                    if (!permissions.TryGetValue(name, out var policiesList)) continue;

//                    //if (name == PermissionNames.Reports)
//                    //{
//                    //    policiesList = CheckReportLicenses(policiesList);
//                    //}
//                    var policies = new List<GetPoliciesResponse>();
//                    foreach (var policy in policiesList)
//                    {
//                        policies.Add(new GetPoliciesResponse(
//                            policy,
//                            policy.ToString()
//                        ));
//                    }
//                    res.Add(new GetPermissionsResponse
//                    (
//                        name,
//                        name.ToString(),
//                        policies
//                    ));
//                }
//            }

//            return res;
//        }

//        private async Task<Dictionary<PermissionNames, List<Policies>>> GetRolePermissionClaims(string roleName)
//        {
//            var role = await roleManager.FindByNameAsync(roleName);
//            var claims = await roleManager.GetClaimsAsync(role);

//            var a = claims
//                .GroupBy(
//                    c => EnumExtensions.Parse<PermissionNames>(c.Type.Split(Role.PermissionClaimSeparator)[0]),
//                    c => EnumExtensions.Parse<Policies>(c.Type.Split(Role.PermissionClaimSeparator)[1])
//                )
//                .ToDictionary(c => c.Key, c => c.ToList())!;
//            return a;
//        }
//    }
//}
