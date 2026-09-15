using BarberSaas.Domain.Entities;
using BarberSaas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberSaas.Application.UseCases.Appointments
{
    public class GetAllAppointmentsUseCase
    {
        private readonly IAppointmentRepository appointmentRepository;

        public GetAllAppointmentsUseCase(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> ExecuteAsync(Guid barbershopId)
        {
            return await appointmentRepository.GetAllAsync(barbershopId);
        }
    }
}