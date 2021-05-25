using Microsoft.EntityFrameworkCore.Migrations;

namespace University.Migrations
{
    public partial class AmazingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Professors",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Professors",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VaccinationStatus",
                table: "Professors",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "VaccinationStatus",
                table: "Professors");
        }
    }
}
