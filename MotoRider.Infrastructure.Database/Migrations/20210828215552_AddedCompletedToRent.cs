using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoRider.Infrastructure.Database.Migrations
{
    public partial class AddedCompletedToRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Rents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Rents");
        }
    }
}
