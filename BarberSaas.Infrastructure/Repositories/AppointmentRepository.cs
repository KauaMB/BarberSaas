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

        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<bool> ScheduleConflictExists(Guid barberId, DateTime startDate, DateTime endDate)
        {
            return await _context.Appointments.AnyAsync(a =>
                a.BarberId == barberId &&
                a.AppointmentStartDate < endDate &&
                a.AppointmentEndDate > startDate);
        }
    }
}