using System;
using System.Collections.Generic;
using System.Text;
using BarberSaas.Domain.Entities;
using BarberSaas.Domain.Repositories;

namespace BarberSaas.Infrastructure.Testing
{
    internal class CreateFakeAppointment : IAppointmentRepository
    {
        private static readonly Guid _barbeiroPaiId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        private static readonly List<Appointment> _bancoDeDadosEmMemoria = new List<Appointment>
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

        public Task CreateNewAppointment(Appointment appointment)
        {
            _bancoDeDadosEmMemoria.Add(appointment);
            return Task.CompletedTask;
        }

        public Task<List<Appointment>> GetAllAppointments()
        {
            return Task.FromResult(_bancoDeDadosEmMemoria);
        }
    
        public Task<bool> ScheduleConflictExists()
}
