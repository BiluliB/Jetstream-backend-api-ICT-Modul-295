using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetstreamApi.Migrations
{
    /// <inheritdoc />
    public partial class addStatusModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4761), new DateTime(2023, 11, 16, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4812) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4823), new DateTime(2023, 11, 17, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4829), new DateTime(2023, 11, 18, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4834), new DateTime(2023, 11, 19, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4835) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4839), new DateTime(2023, 11, 20, 14, 58, 22, 999, DateTimeKind.Local).AddTicks(4840) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9110), new DateTime(2023, 11, 15, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9163) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9176), new DateTime(2023, 11, 16, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9177) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9182), new DateTime(2023, 11, 17, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9183) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9187), new DateTime(2023, 11, 18, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9188) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 14, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9192), new DateTime(2023, 11, 19, 19, 55, 38, 716, DateTimeKind.Local).AddTicks(9193) });
        }
    }
}
