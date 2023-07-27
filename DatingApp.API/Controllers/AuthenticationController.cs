using DatingApp.Application.Interfaces;
using DatingApp.Persistence.DTO.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        private readonly IAuthenticationService _authSerrvice;
        public AuthenticationController(IAuthenticationService authService)
        {
            _authSerrvice = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequest request) {
            var result = await _authSerrvice.Register(request);
            if(result.Success) {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request) {
            var result = await _authSerrvice.Login(request);
            if(result.Success) {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
