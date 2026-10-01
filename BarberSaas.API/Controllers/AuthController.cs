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

        public AuthController(AuthenticateUserUseCase authenticateUserUseCase)
        {
            _authenticateUserUseCase = authenticateUserUseCase;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
              var response = await _authenticateUserUseCase.ExecuteAsync(request);

               return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}