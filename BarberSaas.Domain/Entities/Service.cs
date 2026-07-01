using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Entities
{
    internal class Service
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }

        public Service(string name, TimeSpan duration) {
            Name = name;
            Duration = duration;
        }
    }
}
