using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoRider.Infrastructure.Database.Migrations
{
    public partial class AddedPriceToRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Rents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rents");
        }
    }
}
