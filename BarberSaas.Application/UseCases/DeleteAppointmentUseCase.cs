using BarberSaas.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace BarberSaaS.Application.UseCases
{
    public class DeleteAppointmentUseCase
    {
        private readonly IAppointmentRepository _repository;

        public DeleteAppointmentUseCase(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }

            await _repository.DeleteAsync(appointment);
        }
    }
}