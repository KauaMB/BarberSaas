using System;

namespace BarberSaas.Domain.Entities
{
    public enum UserRole
    {
        Owner = 1,   
        Barber = 2   
    }

    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }

        public Guid BarbershopId { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }

        protected User() { }

        public User(string name, string email, string passwordHash, UserRole role, Guid barbershopId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            BarbershopId = barbershopId;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}