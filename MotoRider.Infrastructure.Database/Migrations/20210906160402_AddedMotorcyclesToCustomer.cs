using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoRider.Infrastructure.Database.Migrations
{
    public partial class AddedMotorcyclesToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Motorcycles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_CustomerId",
                table: "Motorcycles",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Customers_CustomerId",
                table: "Motorcycles",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Customers_CustomerId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_CustomerId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Motorcycles");
        }
    }
}
