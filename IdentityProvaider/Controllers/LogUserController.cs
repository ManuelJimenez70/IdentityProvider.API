using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Commands;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProvaider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogUserController: ControllerBase
    {
        private readonly LogUserServices logUserServices;

        public LogUserController(LogUserServices logUserServices)
        {
            this.logUserServices = logUserServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddLogUser(CreateLogUserCommand createPerfilCommand)
        {
            await logUserServices.HandleCommand(createPerfilCommand);
            return Ok(createPerfilCommand);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogUser(int id)
        {
            var response = await logUserServices.GetPerfil(id);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser(UpdateLogUserCommand updatePerfil)
        {
            await logUserServices.HandleCommand(updatePerfil);
            return Ok(updatePerfil);
        }

    }
}
