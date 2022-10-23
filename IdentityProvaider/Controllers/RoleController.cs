using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProvaider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleServices roleServices;

        public RoleController(RoleServices roleServices)
        {
            this.roleServices = roleServices;
        }
        [HttpPost("createRol")]
        public async Task<IActionResult> AddRole(CreateRoleCommand createRoleCommand)
        {
            await roleServices.HandleCommand(createRoleCommand);
            return Ok(createRoleCommand);
        }

        [HttpGet("getRolById/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var response = await roleServices.GetRole(id);
            return Ok(response);
        }

        [HttpPost("updateRol")]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand updateRole)
        {
            await roleServices.HandleCommand(updateRole);
            return Ok(updateRole);
        }

    }
}
