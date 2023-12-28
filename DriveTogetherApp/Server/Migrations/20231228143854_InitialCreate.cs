using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DriveTogetherApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hausnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PLZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stadt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => x.AdresseId);
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
                name: "Fahrten",
                columns: table => new
                {
                    FahrtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    AutoId = table.Column<int>(type: "int", nullable: false),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnzahlSitzplaetze = table.Column<int>(type: "int", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Storniert = table.Column<bool>(type: "bit", nullable: false),
                    AbfahrtAdresseId = table.Column<int>(type: "int", nullable: false),
                    AnkunftAdresseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fahrten", x => x.FahrtId);
                    table.ForeignKey(
                        name: "FK_Fahrten_Adressen_AbfahrtAdresseId",
                        column: x => x.AbfahrtAdresseId,
                        principalTable: "Adressen",
                        principalColumn: "AdresseId");
                    table.ForeignKey(
                        name: "FK_Fahrten_Adressen_AnkunftAdresseId",
                        column: x => x.AnkunftAdresseId,
                        principalTable: "Adressen",
                        principalColumn: "AdresseId");
                    table.ForeignKey(
                        name: "FK_Fahrten_Autos_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Autos",
                        principalColumn: "AutoId");
                    table.ForeignKey(
                        name: "FK_Fahrten_Benutzers_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzers",
                        principalColumn: "BenutzerId");
                });

            migrationBuilder.CreateTable(
                name: "Buchungen",
                columns: table => new
                {
                    BuchungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buchungsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FahrtId = table.Column<int>(type: "int", nullable: false),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    Storniert = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buchungen", x => x.BuchungId);
                    table.ForeignKey(
                        name: "FK_Buchungen_Benutzers_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzers",
                        principalColumn: "BenutzerId");
                    table.ForeignKey(
                        name: "FK_Buchungen_Fahrten_FahrtId",
                        column: x => x.FahrtId,
                        principalTable: "Fahrten",
                        principalColumn: "FahrtId");
                });

            migrationBuilder.InsertData(
                table: "Benutzers",
                columns: new[] { "BenutzerId", "Email", "Geburtsdatum", "Nachname", "PasswortHash", "PasswortSalt", "Registrierungsdatum", "Telefonnummer", "Vorname" },
                values: new object[] { 1, "max.mustermann@example.com", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mustermann", new byte[0], new byte[0], new DateTime(2023, 12, 28, 15, 38, 54, 246, DateTimeKind.Local).AddTicks(4741), "0123456789", "Max" });

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
                name: "IX_Buchungen_BenutzerId",
                table: "Buchungen",
                column: "BenutzerId");

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_FahrtId",
                table: "Buchungen",
                column: "FahrtId");

            migrationBuilder.CreateIndex(
                name: "IX_Fahrten_AbfahrtAdresseId",
                table: "Fahrten",
                column: "AbfahrtAdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Fahrten_AnkunftAdresseId",
                table: "Fahrten",
                column: "AnkunftAdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Fahrten_AutoId",
                table: "Fahrten",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fahrten_BenutzerId",
                table: "Fahrten",
                column: "BenutzerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buchungen");

            migrationBuilder.DropTable(
                name: "Fahrten");

            migrationBuilder.DropTable(
                name: "Adressen");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Benutzers");
        }
    }
}
