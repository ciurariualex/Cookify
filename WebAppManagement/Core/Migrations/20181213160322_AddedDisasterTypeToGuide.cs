using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class AddedDisasterTypeToGuide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisasterType",
                table: "Guides",
                nullable: false,
                defaultValue: 7);

            migrationBuilder.AlterColumn<int>(
                name: "DisasterType",
                table: "Alerts",
                nullable: false,
                defaultValue: 7,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisasterType",
                table: "Guides");

            migrationBuilder.AlterColumn<int>(
                name: "DisasterType",
                table: "Alerts",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 7);
        }
    }
}
