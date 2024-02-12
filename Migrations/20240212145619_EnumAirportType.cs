using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EnumAirportType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartureAirportId",
                table: "Route",
                newName: "DepartureAirportGroupId");

            migrationBuilder.RenameColumn(
                name: "ArrivalAirportId",
                table: "Route",
                newName: "ArrivalAirportGroupId");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Airport",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartureAirportGroupId",
                table: "Route",
                newName: "DepartureAirportId");

            migrationBuilder.RenameColumn(
                name: "ArrivalAirportGroupId",
                table: "Route",
                newName: "ArrivalAirportId");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Airport",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
