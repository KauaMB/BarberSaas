using BarberSaas.Application.Interfaces.Auth;
using BarberSaas.Domain.Repositories;
using BarberSaas.Infrastructure.Auth;
using BarberSaas.Infrastructure.Data;
using BarberSaas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberSaas.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IBarbershopRepository, BarbershopRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenService, JwtTokenService>();

            return services;
        }
    }
}
