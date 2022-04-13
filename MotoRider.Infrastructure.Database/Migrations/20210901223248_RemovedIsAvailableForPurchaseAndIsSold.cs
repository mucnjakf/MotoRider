using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoRider.Infrastructure.Database.Migrations
{
    public partial class RemovedIsAvailableForPurchaseAndIsSold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableForPurchase",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "Motorcycles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AvailableForPurchase",
                table: "Motorcycles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "Motorcycles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
