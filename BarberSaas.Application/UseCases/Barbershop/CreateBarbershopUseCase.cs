using System.Threading.Tasks;
using BarberSaas.Application.DTOs.Barbershop;
using BarberSaas.Domain.Entities;
using BarberSaas.Domain.Repositories;

namespace BarberSaas.Application.UseCases.Barbershop
{
    public class CreateBarbershopUseCase {
        private readonly IBarbershopRepository _repository;

        public CreateBarbershopUseCase(IBarbershopRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateBarbershopResponse> ExecuteAsync(CreateBarbershopRequest request)
        {
            var barbershop = new Domain.Entities.Barbershop(request.Name, request.Document);          
            await _repository.AddAsync(barbershop);

            return new CreateBarbershopResponse
            {
                Id = barbershop.Id
            };
        }
    }
}