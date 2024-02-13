using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoRider.Infrastructure.Database.Migrations
{
    public partial class ChangedImageToByteArray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Motorcycles"
                );

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Motorcycles",
                type: "varbinary(max)",
                nullable: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Motorcycles"
                );

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Motorcycles",
                type: "nvarchar(max)",
                nullable: true
                );
        }
    }
}
