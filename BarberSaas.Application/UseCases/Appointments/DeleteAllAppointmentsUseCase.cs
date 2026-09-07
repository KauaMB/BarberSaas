using BarberSaas.Domain.Repositories;
using System.Threading.Tasks;

namespace BarberSaas.Application.UseCases.Appointments
{
    public class DeleteAllAppointmentsUseCase
    {
        private readonly IAppointmentRepository _repository;

        public DeleteAllAppointmentsUseCase(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync()
        {
            await _repository.DeleteAllAsync();
        }
    }
}