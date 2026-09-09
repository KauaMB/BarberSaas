using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BarberSaas.Application.UseCases.Barbershop;
using BarberSaas.Application.DTOs.Barbershop;

namespace BarberSaas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarbershopsController : ControllerBase
    {
        private readonly CreateBarbershopUseCase _createBarbershopUseCase;

        public BarbershopsController(CreateBarbershopUseCase createBarbershopUseCase)
        {
            _createBarbershopUseCase = createBarbershopUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBarbershopRequest request)
        { 
            var response = await _createBarbershopUseCase.ExecuteAsync(request);

            return StatusCode(201, response);
        }
    }
}