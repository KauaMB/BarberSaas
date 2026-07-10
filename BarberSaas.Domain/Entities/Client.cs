using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public Client(string name, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhoneNumber = phoneNumber;
        }

    }
}
