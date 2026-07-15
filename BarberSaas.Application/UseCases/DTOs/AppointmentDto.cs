using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BarberSaas.Application.UseCases.DTOs
{
    public record AppointmentDto
    (
        DateTime EndDate,
        DateTime StartDate,
        Guid ClientId,
        Guid ServiceId,
        Guid BarberId = default
    );
}
