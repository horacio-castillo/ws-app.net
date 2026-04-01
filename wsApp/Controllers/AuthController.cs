using Microsoft.AspNetCore.Mvc;
using wsApp.Application.DTOs;
using wsApp.Application.UseCases;

namespace wsApp.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController: ControllerBase
    {
        private readonly RegisterUserUseCase _register;

        public AuthController(RegisterUserUseCase register)
        {
            _register = register;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            await _register.Execute(dto);
            return Ok("Usuario creado");
        }
    }
}



