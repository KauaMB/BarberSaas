using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberSaas.Domain.Entities;
using BarberSaas.Domain.Repositories;
using BarberSaas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BarberSaas.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateNewAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync(Guid barbershopId)
        {
            return await _context.Appointments
                .Where(a => a.BarbershopId == barbershopId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByBarberIdAsync(Guid barberId, Guid barbershopId)
        {
            return await _context.Appointments
               .Where(a => a.BarberId == barberId && a.BarbershopId == barbershopId)
               .ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(Guid id, Guid barbershopId)
        {
            return await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == id && a.BarbershopId == barbershopId);
        }

        public async Task DeleteAsync(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(Guid barbershopId)
        {
            await _context.Appointments
                .Where(a => a.BarbershopId == barbershopId)
                .ExecuteDeleteAsync();
        }

        public async Task<bool> ScheduleConflictExists(Guid barberId, DateTime startDate, DateTime endDate, Guid barbershopId)
        {
            return await _context.Appointments.AnyAsync(a =>
                a.BarberId == barberId &&
                a.BarbershopId == barbershopId &&
                a.AppointmentStartDate < endDate &&
                a.AppointmentEndDate > startDate);
        }
    }
}