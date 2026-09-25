using System;
using System.Threading.Tasks;
using BarberSaas.Application.UseCases.DTOs;
using BarberSaas.Domain.Repositories;
using BCrypt.Net;

namespace BarberSaas.Application.UseCases.Auth
{
    public class AuthenticateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
        {
            // 1. Busca o usuário no banco pelo e-mail
            var user = await _userRepository.GetByEmailAsync(request.Email);

            // Regra de segurança: Sempre retorne a mesma mensagem genérica para e-mail ou senha errados.
            // Isso evita que um atacante descubra quais e-mails estão cadastrados no seu sistema.
            if (user == null)
            {
                throw new UnauthorizedAccessException("E-mail ou senha inválidos.");
            }

            // 2. A Mágica: O BCrypt pega a senha limpa, usa o "Sal" do Hash salvo no banco,"
            // roda o algoritmo e verifica se o resultado é idêntico[cite: 13].
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("E-mail ou senha inválidos."); // Retorna erro caso falhe[cite: 13]
            }

            // 3. Sucesso! A próxima Micro-Task vai substituir esse texto estático pela geração real do JWT.
            return new LoginResponse
            {
                Token = "jwt_token_temporario_aguardando_proxima_task"
            };
        }
    }
}