using Microsoft.AspNetCore.Authorization;
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
        private readonly LoginUserUseCase _login;

        public AuthController(RegisterUserUseCase register,LoginUserUseCase login)
        {
            _register = register;
            _login = login;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            await _register.Execute(dto);
            return Ok(new
            {
                message = "Usuario creado"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _login.Execute(dto);
            return Ok(new { token });
        }

        [HttpPost("pruebaAuthorize")]
        [Authorize]
        public string pruebaAuth()
        {
            return "Validado";
        }
    }
}



