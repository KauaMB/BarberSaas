using System;
using System.Collections.Generic;
using System.Text;
using BarberSaas.Application.UseCases.DTOs;
using BarberSaas.Domain.Entities;
using BarberSaas.Domain.Repositories;

namespace BarberSaas.Application.UseCases
{
    public class CreateAppointmentUseCase
    {
        private readonly IAppointmentRepository appointmentRepository;

        public CreateAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
            if (this.appointmentRepository == null) {
                throw new ArgumentNullException(nameof(appointmentRepository));
            }
        }

        public async Task ExecuteAsync(AppointmentDto appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            if (await appointmentRepository.ScheduleConflictExists(appointment.BarberId, appointment.StartDate, appointment.EndDate))
            {
                throw new InvalidOperationException("Schedule conflict exists for the barber.");
            }

            Appointment newAppointment = new Appointment
            (
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.Empty,
                Guid.NewGuid(),
                appointment.StartDate,
                appointment.EndDate
            );

            await appointmentRepository.CreateNewAppointment(newAppointment);
                
        }
        

    }
}
