using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "AirportGroup",
                columns: table => new
                {
                    AirportGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportGroup", x => x.AirportGroupId);
                });

            migrationBuilder.CreateTable(
                name: "AirportsToAirportGroupsJoins",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "int", nullable: false),
                    AirportGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportsToAirportGroupsJoins", x => new { x.AirportGroupId, x.AirportId });
                    table.ForeignKey(
                        name: "FK_AirportsToAirportGroupsJoins_AirportGroup_AirportGroupId",
                        column: x => x.AirportGroupId,
                        principalTable: "AirportGroup",
                        principalColumn: "AirportGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirportsToAirportGroupsJoins_Airport_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airport",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirportsToAirportGroupsJoins_AirportId",
                table: "AirportsToAirportGroupsJoins",
                column: "AirportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportsToAirportGroupsJoins");

            migrationBuilder.DropTable(
                name: "AirportGroup");

        }
    }
}
