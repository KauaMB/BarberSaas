using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberSaas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExpandMultiTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BarbershopId",
                table: "Barbershops",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BarbershopId",
                table: "Appointments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    BarbershopId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Barbershops_BarbershopId",
                        column: x => x.BarbershopId,
                        principalTable: "Barbershops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BarbershopId",
                table: "Users",
                column: "BarbershopId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BarbershopId",
                table: "Clients",
                column: "BarbershopId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BarbershopId",
                table: "Appointments",
                column: "BarbershopId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_BarbershopId",
                table: "Service",
                column: "BarbershopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Barbershops_BarbershopId",
                table: "Appointments",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Barbershops_BarbershopId",
                table: "Clients",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Barbershops_BarbershopId",
                table: "Users",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Barbershops_BarbershopId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Barbershops_BarbershopId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Barbershops_BarbershopId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Users_BarbershopId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Clients_BarbershopId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BarbershopId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "BarbershopId",
                table: "Barbershops");

            migrationBuilder.DropColumn(
                name: "BarbershopId",
                table: "Appointments");
        }
    }
}
