using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.DAL.Migrations
{
    public partial class ModifiedCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MilageKm",
                table: "Cars");

            migrationBuilder.AddColumn<long>(
                name: "KilometerPrice",
                table: "Categories",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CurrentCarMilageKm",
                table: "CarRentals",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KilometerPrice",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CurrentCarMilageKm",
                table: "CarRentals");

            migrationBuilder.AddColumn<long>(
                name: "MilageKm",
                table: "Cars",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
