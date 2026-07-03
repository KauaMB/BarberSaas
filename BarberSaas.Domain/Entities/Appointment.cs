using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Entities
{
    internal class Appointment
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid BarberId { get; private set; }
        public Guid ServiceId { get; private set; }
        public DateTime AppointmentStartDate { get; private set; }
        public DateTime AppointmentEndDate { get; private set; }
    }
}
