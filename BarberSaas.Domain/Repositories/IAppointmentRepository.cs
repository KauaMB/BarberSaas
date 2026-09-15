using BarberSaas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task CreateNewAppointmentAsync(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAllAsync(Guid barbershopId);
        Task<IEnumerable<Appointment>> GetByBarberIdAsync(Guid barberId, Guid barbershopId);
        Task<bool> ScheduleConflictExists(Guid barberId, DateTime startDate, DateTime endDate, Guid barbershopId);
        Task<Appointment?> GetByIdAsync(Guid id, Guid barbershopId);
        Task DeleteAsync(Appointment appointment);
        Task DeleteAllAsync(Guid barbershopId);

    }
}
