using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class initialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "AppUsers",
                newName: "AuthToken");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AppUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AppUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "AppUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "AppUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "AppUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AppUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserTypeString",
                table: "AppUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UserTypeString",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "AuthToken",
                table: "AppUsers",
                newName: "Token");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUsers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AppUsers",
                maxLength: 4001,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AppUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
