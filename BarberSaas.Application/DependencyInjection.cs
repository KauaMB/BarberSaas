using BarberSaas.Application.UseCases.Appointments;
using BarberSaas.Application.UseCases.Auth;
using BarberSaas.Application.UseCases.Barbershop;
using BarberSaas.Application.UseCases.Users;
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
            services.AddScoped<DeleteAppointmentUseCase>();
            services.AddScoped<DeleteAllAppointmentsUseCase>();
            services.AddScoped<CreateBarbershopUseCase>();
            services.AddScoped<AuthenticateUserUseCase>();
            services.AddScoped<CreateUserUseCase>();

            return services;
        }
    }
}

    

