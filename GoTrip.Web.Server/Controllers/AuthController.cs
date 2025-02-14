using GoTrip.Aplicaciones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoTrip.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAutenticacionService _autenticacionService;

        public AuthController(IAutenticacionService autenticacionService)
        {
            _autenticacionService = autenticacionService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userResponse = await _autenticacionService.Login(username, password);
                return Ok(userResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
