using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace IdentityProvaider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserServices userServices;

        public UserController(UserServices userServices)
        {
            this.userServices = userServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddPerfile(CreateUserCommand createPerfilCommand)
        {
            await userServices.HandleCommand(createPerfilCommand);
            return Ok(createPerfilCommand);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfil(int id)
        {
            var response = await userServices.GetPerfil(id);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdatePerfil(UpdateUserCommand updatePerfil)
        {
            await userServices.HandleCommand(updatePerfil);
            return Ok(updatePerfil);
        }

    }
}
