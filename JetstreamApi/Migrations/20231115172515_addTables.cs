using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JetstreamApi.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriorityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "PriorityName" },
                values: new object[,]
                {
                    { 1, "Tief" },
                    { 2, "Standard" },
                    { 3, "Hoch" }
                });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5708), new DateTime(2023, 11, 16, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5753) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5760), new DateTime(2023, 11, 17, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5764), new DateTime(2023, 11, 18, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5765) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5767), new DateTime(2023, 11, 19, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5768) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5771), new DateTime(2023, 11, 20, 18, 25, 15, 502, DateTimeKind.Local).AddTicks(5771) });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ServiceName" },
                values: new object[,]
                {
                    { 1, "Kleiner Service" },
                    { 2, "Großer Service" },
                    { 3, "Rennskiservice" },
                    { 4, "Bindung montieren und einstellen" },
                    { 5, "Fell zuschneiden" },
                    { 6, "Heißwachsen" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Offen" },
                    { 2, "In Arbeit" },
                    { 3, "Abgeschlossen" },
                    { 4, "Storniert" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(253), new DateTime(2023, 11, 16, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(311), new DateTime(2023, 11, 17, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(312) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(315), new DateTime(2023, 11, 18, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(316) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(318), new DateTime(2023, 11, 19, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(319) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(321), new DateTime(2023, 11, 20, 18, 12, 25, 745, DateTimeKind.Local).AddTicks(322) });
        }
    }
}
