using BarberSaas.Application;
using BarberSaas.Application.UseCases;
using BarberSaas.Domain.Repositories;
using BarberSaas.Infrastructure.Testing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddScoped<IAppointmentRepository, CreateFakeAppointment>();

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
    
app.MapControllers();

app.UseHttpsRedirection();


app.Run();
