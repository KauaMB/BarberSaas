using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Entities
{
    internal class Appointment
    {
        public string ClientName { get; set; }
        public string BarberName { get; set; }
        public string ServiceName { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
