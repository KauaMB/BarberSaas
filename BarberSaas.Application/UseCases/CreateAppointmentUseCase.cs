using System;
using System.Collections.Generic;
using System.Text;
using BarberSaas.Domain.Repositories;

namespace BarberSaas.Application.UseCases
{
    internal class CreateAppointmentUseCase
    {
        private readonly IAppointmentRepository appointmentRepository;

        public CreateAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }



    }
}
