using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JetstreamApi.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "Comment", "CreateDate", "Email", "Firstname", "Lastname", "Phone", "PickupDate", "Price", "Priority", "ServiceId", "StatusId" },
                values: new object[,]
                {
                    { 1, "Erster Kommentar", new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9110), "max.mustermann@example.com", "Max", "Mustermann", "1234567890", new DateTime(2023, 11, 15, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9163), 100.00m, 1, 1, 1 },
                    { 2, "Zweiter Kommentar", new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9176), "maria.musterfrau@example.com", "Maria", "Musterfrau", "0987654321", new DateTime(2023, 11, 16, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9177), 80.50m, 2, 2, 2 },
                    { 3, "Dritter Kommentar", new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9182), "johannes.doe@example.com", "Johannes", "Doe", "1122334455", new DateTime(2023, 11, 17, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9183), 75.00m, 1, 3, 3 },
                    { 4, "Vierter Kommentar", new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9187), "anna.beispiel@example.com", "Anna", "Beispiel", "2233445566", new DateTime(2023, 11, 18, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9188), 120.00m, 3, 4, 2 },
                    { 5, "Fünfter Kommentar", new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9192), "lukas.muster@example.com", "Lukas", "Muster", "3344556677", new DateTime(2023, 11, 19, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9193), 200.00m, 2, 5, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
