using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class FixedImplementationCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Alerts");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Alerts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Alerts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Alerts");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Alerts",
                maxLength: 4001,
                nullable: false,
                defaultValue: "");
        }
    }
}
