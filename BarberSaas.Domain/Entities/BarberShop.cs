using System;

namespace BarberSaas.Domain.Entities
{
    public class Barbershop
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; } //owner document (CNPJ or CPF)
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }

        protected Barbershop() { }

        public Barbershop(string name, string document)
        {
            Id = Guid.NewGuid();
            Name = name;
            Document = document;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}