using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeographyLevel1",
                columns: table => new
                {
                    GeographyLevel1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_GeographyLevel1Id", x => x.GeographyLevel1Id);
                    table.UniqueConstraint("AK_GeographyLevel1_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IATACode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeographyLevel1Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.AirportId);
                    table.ForeignKey(
                        name: "FK_Airport_GeographyLevel1_GeographyLevel1Id",
                        column: x => x.GeographyLevel1Id,
                        principalTable: "GeographyLevel1",
                        principalColumn: "GeographyLevel1Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airport_GeographyLevel1Id",
                table: "Airport",
                column: "GeographyLevel1Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "GeographyLevel1");
        }
    }
}
