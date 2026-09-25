using BarberSaas.Domain.Entities;

namespace BarberSaas.Application.Interfaces.Auth
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}