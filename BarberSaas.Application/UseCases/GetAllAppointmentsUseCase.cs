using BarberSaas.Domain.Entities;
using BarberSaas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Application.UseCases
{
    public class GetAllAppointmentsUseCase
    {
        private readonly IAppointmentRepository appointmentRepository;

        public GetAllAppointmentsUseCase(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public async Task<List<Appointment>> ExecuteAsync()
        {
            return await appointmentRepository.GetAllAppointments();
        }
    }
}
