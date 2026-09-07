using System;
using System.Threading.Tasks;
using BarberSaas.Domain.Entities;

namespace BarberSaas.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
    }
}