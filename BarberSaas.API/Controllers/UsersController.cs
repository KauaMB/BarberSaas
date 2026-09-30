using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BarberSaas.Application.UseCases.Users;
using BarberSaas.Application.UseCases.DTOs.User;

namespace BarberSaas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;

        public UsersController(CreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request){ 
            var response = await _createUserUseCase.ExecuteAsync(request);

            return Created(string.Empty, response);
        }
    }
}