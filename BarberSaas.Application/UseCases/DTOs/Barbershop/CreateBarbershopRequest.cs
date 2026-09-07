namespace BarberSaas.Application.DTOs.Barbershop
{
    public class CreateBarbershopRequest
    {
        public string Name { get; set; }
        public string Document { get; set; } // cpf||cnpj

    }
}