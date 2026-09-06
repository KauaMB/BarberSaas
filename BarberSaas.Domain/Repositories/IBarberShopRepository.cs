using System;
using System.Threading.Tasks;
using BarberSaas.Domain.Entities;

namespace BarberSaas.Domain.Repositories
{
    public interface IBarbershopRepository
    {
        Task AddAsync(Barbershop barbershop);
        Task<Barbershop> GetByIdAsync(Guid id);
        Task UpdateAsync(Barbershop barbershop);
    }
}