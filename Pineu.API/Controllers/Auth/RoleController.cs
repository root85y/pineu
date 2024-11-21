//using System.Security.Claims;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Pineu.API.DTOs.Auth.Roles;
//using Serilog;
//using Shared.Helpers;
//using X.PagedList;
//using Pineu.Persistence.AuthEntities;
//using Pineu.Persistence.Constants.Enums;
//using Pineu.API.DTOs.Primitives;

//namespace Pineu.API.Controllers.Auth
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RoleController(RoleManager<Role> roleManager) : ControllerBase
//    {
//        [HttpGet, Authorize(policy: "2:1")]
//        public async Task<IActionResult> Get([FromQuery] Guid id)
//        {
//            var role = await roleManager.Roles
//                  .Where(role => role.Id == id)
//                  .FirstOrDefaultAsync();
//            if (role == null)
//                return BadRequest(new { Message = "Role not found" });

//            return Ok(new GetRoleResponse(role.Id, role.Name, await GetRolePermissionsAsync(role)));
//        }

//        [HttpGet, Route("All"), Authorize(policy: "2:1")]
//        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest pagination, [FromQuery] SearchFilters filters)
//        {
//            var query = roleManager.Roles
//                  .Where(r => r.NormalizedName != "ADMIN")
//                  .AsQueryable();

//            if (filters.Search != null) query = query.Where(r => r.Name.Contains(filters.Search));

//            if (pagination.Page.HasValue && pagination.PageSize.HasValue)
//            {
//                var pagedRoles = await query
//                    .ToPagedListAsync(pagination.Page.Value, pagination.PageSize.Value);

//                var pagedRes = new List<GetRoleResponse>();

//                foreach (var role in pagedRoles)
//                {
//                    pagedRes.Add(new GetRoleResponse
//                    (
//                        Id: role.Id,
//                        Name: role.Name,
//                        Permissions: await GetRolePermissionsAsync(role)
//                    ));
//                }

//                return Ok(new { List = pagedRes, Count = query.Count() });
//            }

//            var roles = await query
//                .ToListAsync();

//            var res = new List<GetRoleResponse>();

//            foreach (var role in roles)
//            {
//                res.Add(new GetRoleResponse
//                (
//                    Id: role.Id,
//                    Name: role.Name,
//                    Permissions: await GetRolePermissionsAsync(role)
//                ));
//            }

//            return Ok(new { List = res, Count = res.Count });
//        }

//        [HttpPost, Authorize(policy: "2:0")]
//        public async Task<IActionResult> Create([FromBody] AddRoleRequest request)
//        {
//            if (await roleManager.RoleExistsAsync(request.Name))
//                return BadRequest(new { Message = "Role not found" });

//            var role = new Role { Name = request.Name, NormalizedName = request.Name.ToUpper() };
//            var permissions = new List<Claim>();
//            await roleManager.CreateAsync(role);
//            foreach (var permissionDTO in request.Permissions)
//                foreach (var policy in permissionDTO.Value)
//                {
//                    var type = $"{permissionDTO.Key}{Role.PermissionClaimSeparator}{policy}";
//                    await roleManager.AddClaimAsync(role, new Claim(type, type));
//                }

//            Log.Logger.Information("Role \"{@object}\" created with Id {id}", request, role.Id);

//            return Ok();
//        }

//        [HttpPut, Authorize(policy: "2:2")]
//        public async Task<IActionResult> Update([FromQuery] string id, [FromBody] AddRoleRequest request)
//        {
//            var role = await roleManager.FindByIdAsync(id);

//            if (role == null)
//                return BadRequest(new { Message = "Role not found" });

//            if (role.Name != request.Name && await roleManager.RoleExistsAsync(request.Name))
//                return BadRequest(new { Message = "A role with this name already exist" });

//            role.Name = request.Name;
//            role.NormalizedName = request.Name.ToUpper();
//            await roleManager.UpdateAsync(role);


//            var claims = await roleManager.GetClaimsAsync(role);
//            foreach (var claim in claims)
//                await roleManager.RemoveClaimAsync(role, claim);

//            foreach (var permissionDTO in request.Permissions)
//                foreach (var policy in permissionDTO.Value)
//                {
//                    var type = $"{permissionDTO.Key}{Role.PermissionClaimSeparator}{policy}";
//                    await roleManager.AddClaimAsync(role, new Claim(type, type));
//                }

//            Log.Logger.Information("Role \"{@object}\" updated with Id {id}", request, role.Id);

//            return Ok();
//        }

//        [HttpDelete, Authorize(policy: "2:5")]
//        public async Task<IActionResult> Delete([FromQuery] string id)
//        {
//            var role = await roleManager.FindByIdAsync(id);

//            if (role == null)
//                return BadRequest(new { Message = "Role not found" });

//            var res = await roleManager.DeleteAsync(role);

//            Log.Logger.Information("Role deleted with Id {id}", role.Id);

//            return Ok();
//        }

//        private async Task<Dictionary<PermissionNames, List<Policies>>> GetRolePermissionsAsync(Role role)
//        {
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
