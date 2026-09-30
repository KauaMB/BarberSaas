using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BarberSaas.Application.UseCases.Auth;
using BarberSaas.Application.UseCases.DTOs.User;

namespace BarberSaas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticateUserUseCase _authenticateUserUseCase;

        // Injetamos o caso de uso diretamente pelo construtor
        public AuthController(AuthenticateUserUseCase authenticateUserUseCase)
        {
            _authenticateUserUseCase = authenticateUserUseCase;
        }

        // Endpoint exigido pela task[cite: 8]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                // Chama o caso de uso[cite: 8]
                var response = await _authenticateUserUseCase.ExecuteAsync(request);

                // Se a password estiver correta, devolve o Token com Status 200 (OK)
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Se a password ou o e-mail falharem, o caso de uso lança a exceção e nós devolvemos o 401
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}