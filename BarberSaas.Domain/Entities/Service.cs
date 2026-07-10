using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public TimeSpan Duration { get; private set; }
        public decimal Price { get; private set; }

        public Service(string name, TimeSpan duration, decimal price) {
            Id = Guid.NewGuid();
            Name = name;
            Duration = duration;
            Price = price;
        }
    }
}
