using BarberSaas.Application.Interfaces.Auth;
using BarberSaas.Application.UseCases.DTOs.User;
using BarberSaas.Domain.Repositories;
using BCrypt.Net;
using System;
using System.Threading.Tasks;

namespace BarberSaas.Application.UseCases.Auth
{
    public class AuthenticateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticateUserUseCase(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("E-mail ou senha inválidos.");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("E-mail ou senha inválidos.");
            }

            var token = _tokenService.GenerateToken(user);

            return new LoginResponse
            {
                Token = token
            };
        }
    }
}