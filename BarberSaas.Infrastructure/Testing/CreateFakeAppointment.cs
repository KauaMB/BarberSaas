using System;
using System.Collections.Generic;
using System.Text;
using BarberSaas.Domain.Entities;
using BarberSaas.Domain.Repositories;

namespace BarberSaas.Infrastructure.Testing
{
    public class CreateFakeAppointment : IAppointmentRepository
    {
        public static readonly Guid _barbeiroPaiId = Guid.Empty;

        private static readonly List<Appointment> inMemoryDatabase = new List<Appointment>
        {
            new Appointment(
                Guid.NewGuid(),
                Guid.NewGuid(),
                _barbeiroPaiId,
                Guid.NewGuid(),
                new DateTime(2026, 7, 10, 9, 0, 0),
                new DateTime(2026, 7, 10, 9, 40, 0)
            ),

            new Appointment(
                Guid.NewGuid(),
                Guid.NewGuid(),
                _barbeiroPaiId,
                Guid.NewGuid(),
                new DateTime(2026, 7, 10, 10, 0, 0),
                new DateTime(2026, 7, 10, 11, 0, 0)
            ),

            new Appointment(
                Guid.NewGuid(),
                Guid.NewGuid(),
                _barbeiroPaiId,
                Guid.NewGuid(),
                new DateTime(2026, 7, 10, 14, 0, 0),
                new DateTime(2026, 7, 10, 14, 30, 0)
            ),

            new Appointment(
                Guid.NewGuid(),
                Guid.NewGuid(),
                _barbeiroPaiId,
                Guid.NewGuid(),
                new DateTime(2026, 7, 11, 9, 0, 0),
                new DateTime(2026, 7, 11, 9, 40, 0)
            ),

            new Appointment(
                Guid.NewGuid(),
                Guid.NewGuid(),
                _barbeiroPaiId,
                Guid.NewGuid(),
                new DateTime(2026, 7, 11, 15, 0, 0),
                new DateTime(2026, 7, 11, 16, 0, 0)
            )
        };


        public Task<List<Appointment>> GetAllAppointments()
        {
            return Task.FromResult(inMemoryDatabase);
        }

        public Task<bool> ScheduleConflictExists(Guid barberId, DateTime startDate, DateTime endDate)
        {
            var conflictExists = inMemoryDatabase.Any(a =>
            a.BarberId == barberId && (startDate < a.AppointmentEndDate &&
            endDate > a.AppointmentStartDate));
            
            return Task.FromResult(conflictExists);
        }
        public Task CreateNewAppointment(Appointment appointment)
        {
            inMemoryDatabase.Add(appointment);
            return Task.CompletedTask;
        }

    }
}
