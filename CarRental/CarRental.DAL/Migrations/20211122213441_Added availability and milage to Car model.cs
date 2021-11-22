using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.DAL.Migrations
{
    public partial class AddedavailabilityandmilagetoCarmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "MilageKm",
                table: "Cars",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MilageKm",
                table: "Cars");
        }
    }
}
