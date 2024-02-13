using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoRider.Infrastructure.Database.Migrations
{
    public partial class RemovedImageFromMotorcycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Motorcycles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Motorcycles",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
