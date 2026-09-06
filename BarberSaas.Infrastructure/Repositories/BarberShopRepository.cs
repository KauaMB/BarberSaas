using System;
using System.Threading.Tasks;
using BarberSaas.Domain.Entities;
using BarberSaas.Domain.Repositories;
using BarberSaas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BarberSaas.Infrastructure.Repositories
{
    public class BarberShopRepository : IBarbershopRepository
    {
        private readonly ApplicationDbContext _context;

        public BarberShopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Barbershop barbershop)
        {
            await _context.Barbershops.AddAsync(barbershop);
            await _context.SaveChangesAsync();
        }

        public async Task<Barbershop> GetByIdAsync(Guid id)
        {
            return await _context.Barbershops.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Barbershop barbershop)
        {
            _context.Barbershops.Update(barbershop);
            await _context.SaveChangesAsync();
        }
    }
} 