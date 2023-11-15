﻿// <auto-generated />
using System;
using JetstreamApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JetstreamApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JetstreamApi.Models.ServiceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ServiceRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Erster Kommentar",
                            CreateDate = new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9110),
                            Email = "max.mustermann@example.com",
                            Firstname = "Max",
                            Lastname = "Mustermann",
                            Phone = "1234567890",
                            PickupDate = new DateTime(2023, 11, 15, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9163),
                            Price = 100.00m,
                            Priority = 1,
                            ServiceId = 1,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            Comment = "Zweiter Kommentar",
                            CreateDate = new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9176),
                            Email = "maria.musterfrau@example.com",
                            Firstname = "Maria",
                            Lastname = "Musterfrau",
                            Phone = "0987654321",
                            PickupDate = new DateTime(2023, 11, 16, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9177),
                            Price = 80.50m,
                            Priority = 2,
                            ServiceId = 2,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 3,
                            Comment = "Dritter Kommentar",
                            CreateDate = new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9182),
                            Email = "johannes.doe@example.com",
                            Firstname = "Johannes",
                            Lastname = "Doe",
                            Phone = "1122334455",
                            PickupDate = new DateTime(2023, 11, 17, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9183),
                            Price = 75.00m,
                            Priority = 1,
                            ServiceId = 3,
                            StatusId = 3
                        },
                        new
                        {
                            Id = 4,
                            Comment = "Vierter Kommentar",
                            CreateDate = new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9187),
                            Email = "anna.beispiel@example.com",
                            Firstname = "Anna",
                            Lastname = "Beispiel",
                            Phone = "2233445566",
                            PickupDate = new DateTime(2023, 11, 18, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9188),
                            Price = 120.00m,
                            Priority = 3,
                            ServiceId = 4,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 5,
                            Comment = "Fünfter Kommentar",
                            CreateDate = new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9192),
                            Email = "lukas.muster@example.com",
                            Firstname = "Lukas",
                            Lastname = "Muster",
                            Phone = "3344556677",
                            PickupDate = new DateTime(2023, 11, 19, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9193),
                            Price = 200.00m,
                            Priority = 2,
                            ServiceId = 5,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("JetstreamApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
