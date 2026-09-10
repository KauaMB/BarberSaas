using BarberSaas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberSaas.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Barbershop> Barbershops { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne<Barbershop>() 
                .WithMany()           
                .HasForeignKey(u => u.BarbershopId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne<Barbershop>()
                .WithMany()
                .HasForeignKey(c => c.BarbershopId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne<Barbershop>()
                .WithMany()
                .HasForeignKey(a => a.BarbershopId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasOne<Barbershop>()
                .WithMany()
                .HasForeignKey(s => s.BarbershopId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}