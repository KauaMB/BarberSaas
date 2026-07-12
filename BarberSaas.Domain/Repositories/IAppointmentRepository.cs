using BarberSaas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        public Task CreateNewAppointment(Appointment appointment);

        public Task<List<Appointment>> GetAllAppointments();

        public Task<bool> ScheduleConflictExists(Guid barberId, DateTime startDate, DateTime endDate);
    }
}
