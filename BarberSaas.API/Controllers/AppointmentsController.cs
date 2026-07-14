using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BarberSaas.Application.UseCases;
using BarberSaas.Application.UseCases.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

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
            if (createAppointmentUseCase == null)
            {
                throw new ArgumentNullException(nameof(createAppointmentUseCase));
            }
            if (getAllAppointmentsUseCase == null)
            {
                throw new ArgumentNullException(nameof(getAllAppointmentsUseCase));
            }
            _createAppointmentUseCase = createAppointmentUseCase;
            _getAllAppointmentsUseCase = getAllAppointmentsUseCase;
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
                // 
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                var appointments = await _getAllAppointmentsUseCase.ExecuteAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
