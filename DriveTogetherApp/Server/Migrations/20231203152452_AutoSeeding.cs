using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DriveTogetherApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AutoSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "AutoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "AutoId",
                keyValue: 2);
        }
    }
}
