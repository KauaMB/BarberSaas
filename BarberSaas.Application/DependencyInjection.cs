using BarberSaas.Application.UseCases;
using BarberSaas.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<CreateAppointmentUseCase>();
            services.AddScoped<GetAllAppointmentsUseCase>();

            return services;
        }
    }
}

    

