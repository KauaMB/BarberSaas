using BarberSaas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task CreateNewAppointmentAsync(Appointment appointment);

        Task<List<Appointment>> GetAllAppointmentsAsync();

        Task<bool> ScheduleConflictExists(Guid barberId, DateTime startDate, DateTime endDate);
    }
}
