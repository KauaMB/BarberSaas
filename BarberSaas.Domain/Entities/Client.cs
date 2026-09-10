using System;

namespace BarberSaas.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; } 

        public Guid BarbershopId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        protected Client() { }

        public Client(string name, string phoneNumber, Guid barbershopId)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhoneNumber = phoneNumber;
            BarbershopId = barbershopId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}