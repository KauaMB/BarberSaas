using BarberSaas.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BarberSaas.Application.UseCases.AppointmentUseCases;

namespace BarberSaas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<CreateAppointmentUseCase>();
            services.AddScoped<GetAllAppointmentsUseCase>();
            services.AddScoped<DeleteAppointmentUseCase>();
            services.AddScoped<DeleteAllAppointmentsUseCase>();

            return services;
        }
    }
}

    

