﻿// <auto-generated />
using System;
using DriveTogetherApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DriveTogetherApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DriveTogetherApp.Shared.Model.Auto", b =>
                {
                    b.Property<int>("AutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoId"));

                    b.Property<DateTime>("Baujahr")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fahrtenanbieter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Farbe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kennzeichen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marke")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modell")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutoId");

                    b.ToTable("Autos");

                    b.HasData(
                        new
                        {
                            AutoId = 1,
                            Baujahr = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fahrtenanbieter = "Markus Transporte",
                            Farbe = "Blau",
                            Kennzeichen = "B-MK 1234",
                            Marke = "Volkswagen",
                            Modell = "Golf",
                            Typ = "Kompakt"
                        },
                        new
                        {
                            AutoId = 2,
                            Baujahr = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fahrtenanbieter = "Markus Transporte",
                            Farbe = "Blau",
                            Kennzeichen = "B-MK 1234",
                            Marke = "Volkswagen",
                            Modell = "Golf",
                            Typ = "Kompakt"
                        });
                });

            modelBuilder.Entity("DriveTogetherApp.Shared.Model.Benutzer", b =>
                {
                    b.Property<int>("BenutzerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BenutzerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Geburtsdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswortHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswortSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("Registrierungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Telefonnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BenutzerId");

                    b.ToTable("Benutzers");
                });
#pragma warning restore 612, 618
        }
    }
}
