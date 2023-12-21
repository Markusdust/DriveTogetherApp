using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DriveTogetherApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benutzers",
                columns: table => new
                {
                    BenutzerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswortHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswortSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Geburtsdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registrierungsdatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzers", x => x.BenutzerId);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    Marke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Farbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kennzeichen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Baujahr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.AutoId);
                    table.ForeignKey(
                        name: "FK_Autos_Benutzers_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzers",
                        principalColumn: "BenutzerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fahrt",
                columns: table => new
                {
                    FahrtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    AutoId = table.Column<int>(type: "int", nullable: false),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enddatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnzahlSitzplaetze = table.Column<int>(type: "int", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fahrt", x => x.FahrtId);
                    table.ForeignKey(
                        name: "FK_Fahrt_Autos_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Autos",
                        principalColumn: "AutoId");
                    table.ForeignKey(
                        name: "FK_Fahrt_Benutzers_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzers",
                        principalColumn: "BenutzerId");
                });

            migrationBuilder.InsertData(
                table: "Benutzers",
                columns: new[] { "BenutzerId", "Email", "Geburtsdatum", "Nachname", "PasswortHash", "PasswortSalt", "Registrierungsdatum", "Telefonnummer", "Vorname" },
                values: new object[] { 1, "max.mustermann@example.com", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mustermann", new byte[0], new byte[0], new DateTime(2023, 12, 21, 11, 31, 32, 944, DateTimeKind.Local).AddTicks(6907), "0123456789", "Max" });

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "AutoId", "Baujahr", "BenutzerId", "Farbe", "Kennzeichen", "Marke", "Modell", "Typ" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rot", "B-MK 1234", "Volkswagen", "Polo", "SUV" },
                    { 2, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Blau", "B-MK 1234", "Volkswagen", "Golf", "Limousine" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_BenutzerId",
                table: "Autos",
                column: "BenutzerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fahrt_AutoId",
                table: "Fahrt",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fahrt_BenutzerId",
                table: "Fahrt",
                column: "BenutzerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fahrt");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Benutzers");
        }
    }
}
