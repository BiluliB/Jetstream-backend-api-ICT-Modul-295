using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetstreamApi.Migrations
{
    /// <inheritdoc />
    public partial class someFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8638), new DateTime(2023, 11, 16, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8688), new DateTime(2023, 11, 17, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8689) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8692), new DateTime(2023, 11, 18, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8692) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8695), new DateTime(2023, 11, 19, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8696) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8698), new DateTime(2023, 11, 20, 22, 20, 13, 273, DateTimeKind.Local).AddTicks(8698) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(5988), new DateTime(2023, 11, 16, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(6043) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(6054), new DateTime(2023, 11, 17, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(6055) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(6059), new DateTime(2023, 11, 18, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(6060) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(6062), new DateTime(2023, 11, 19, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(6066), new DateTime(2023, 11, 20, 20, 55, 37, 573, DateTimeKind.Local).AddTicks(6066) });
        }
    }
}
