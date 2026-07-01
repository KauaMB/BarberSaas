using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Entities
{
    internal class Barber
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }

        public Barber (string name, string phoneNumber)
        {
            Id = Guid.NewGuid(); 
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
