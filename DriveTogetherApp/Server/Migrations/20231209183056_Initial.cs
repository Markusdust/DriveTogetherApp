using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DriveTogetherApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fahrtenanbieter = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                });

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

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "AutoId", "Baujahr", "Fahrtenanbieter", "Farbe", "Kennzeichen", "Marke", "Modell", "Typ" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Markus Transporte", "Blau", "B-MK 1234", "Volkswagen", "Golf", "Kompakt" },
                    { 2, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Markus Transporte", "Blau", "B-MK 1234", "Volkswagen", "Golf", "Kompakt" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Benutzers");
        }
    }
}
