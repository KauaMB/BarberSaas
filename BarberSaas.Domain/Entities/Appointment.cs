using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid BarberId { get; private set; }
        public Guid ServiceId { get; private set; }
        public DateTime AppointmentStartDate { get; private set; }
        public DateTime AppointmentEndDate { get; private set; }

        public Appointment(Guid id, Guid clientId, Guid barberId, Guid serviceId, DateTime appointmentStartDate, DateTime appointmentEndDate)
        {
            Id = id;
            ClientId = clientId;
            BarberId = barberId;
            ServiceId = serviceId;
            AppointmentStartDate = appointmentStartDate;
            AppointmentEndDate = appointmentEndDate;
        }
    }

}
