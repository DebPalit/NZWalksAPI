using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Services;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthSercive authService;

        public AuthController(IAuthSercive authService)
        {
            this.authService = authService;
        }

        // POST: /api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registerResult = await authService.RegisterAsync(dto);

            if (registerResult == null)
                return BadRequest(registerResult);

            return Ok(registerResult);
        }

        // POST: /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await authService.LoginAsync(dto);

            if (token == null)
                return Unauthorized("Invalid email or password.");

            return Ok(new LoginResponseDto { JwtToken = token });
        }
    }
}
