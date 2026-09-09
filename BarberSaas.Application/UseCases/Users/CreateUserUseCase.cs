using System;
using System.Threading.Tasks;
using BarberSaas.Application.DTOs.User;
using BarberSaas.Domain.Entities;
using BarberSaas.Domain.Repositories;

namespace BarberSaas.Application.UseCases.Users
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IBarbershopRepository _barbershopRepository;

        // Injetamos os dois repositórios
        public CreateUserUseCase(IUserRepository userRepository, IBarbershopRepository barbershopRepository)
        {
            _userRepository = userRepository;
            _barbershopRepository = barbershopRepository;
        }

        public async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest request)
        {
            var barbershop = await _barbershopRepository.GetByIdAsync(request.BarbershopId);
            if (barbershop == null)
            {
                throw new ArgumentException("A barbearia informada não existe no sistema.");
            }

            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Este e-mail já está cadastrado no sistema.");
            }

            if (!Enum.IsDefined(typeof(UserRole), request.Role))
            {
                throw new ArgumentException("O perfil de usuário informado é inválido.");
            }

            var roleEnum = (UserRole)request.Role;

            var user = new User(
                request.Name,
                request.Email,
                request.Password,
                roleEnum, 
                request.BarbershopId
            );

            await _userRepository.AddAsync(user);

            return new CreateUserResponse
            {
                Id = user.Id
            };
        }
    
    }
}