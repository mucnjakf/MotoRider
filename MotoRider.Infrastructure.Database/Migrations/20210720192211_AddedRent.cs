using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoRider.Infrastructure.Database.Migrations
{
    public partial class AddedRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRented = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentedUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotorcycleId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CustomerId",
                table: "Rents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_MotorcycleId",
                table: "Rents",
                column: "MotorcycleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");
        }
    }
}
