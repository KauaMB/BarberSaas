using BarberSaas.Application.UseCases.Appointments;
using BarberSaas.Application.UseCases.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BarberSaas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly CreateAppointmentUseCase _createAppointmentUseCase;
        private readonly GetAllAppointmentsUseCase _getAllAppointmentsUseCase;

        public AppointmentsController(CreateAppointmentUseCase createAppointmentUseCase, GetAllAppointmentsUseCase getAllAppointmentsUseCase)
        {
            _createAppointmentUseCase = createAppointmentUseCase ?? throw new ArgumentNullException(nameof(createAppointmentUseCase));
            _getAllAppointmentsUseCase = getAllAppointmentsUseCase ?? throw new ArgumentNullException(nameof(getAllAppointmentsUseCase));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest("Appointment data is required.");
            }
            try
            {
                await _createAppointmentUseCase.ExecuteAsync(appointmentDto);
                return Ok("Appointment created successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments([FromHeader(Name = "X-Barbershop-Id")] Guid barbershopId)
        {
            try
            {
                var appointments = await _getAllAppointmentsUseCase.ExecuteAsync(barbershopId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, [FromHeader(Name = "X-Barbershop-Id")] Guid barbershopId, [FromServices] DeleteAppointmentUseCase useCase)
        {
            try
            {
                await useCase.ExecuteAsync(id, barbershopId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAll([FromHeader(Name = "X-Barbershop-Id")] Guid barbershopId, [FromServices] DeleteAllAppointmentsUseCase useCase)
        {
            await useCase.ExecuteAsync(barbershopId);
            return NoContent();
        }
    }
}