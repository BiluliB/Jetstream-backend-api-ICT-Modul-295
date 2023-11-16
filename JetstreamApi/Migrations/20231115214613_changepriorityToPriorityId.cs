using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetstreamApi.Migrations
{
    /// <inheritdoc />
    public partial class changepriorityToPriorityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "ServiceRequests",
                newName: "PriorityId");

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(391), new DateTime(2023, 11, 16, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(440), new DateTime(2023, 11, 17, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(441) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(444), new DateTime(2023, 11, 18, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(444) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(447), new DateTime(2023, 11, 19, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "PickupDate" },
                values: new object[] { new DateTime(2023, 11, 15, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(450), new DateTime(2023, 11, 20, 22, 46, 13, 768, DateTimeKind.Local).AddTicks(451) });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_PriorityId",
                table: "ServiceRequests",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ServiceId",
                table: "ServiceRequests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_StatusId",
                table: "ServiceRequests",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Priorities_PriorityId",
                table: "ServiceRequests",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Services_ServiceId",
                table: "ServiceRequests",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Status_StatusId",
                table: "ServiceRequests",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Priorities_PriorityId",
                table: "ServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Services_ServiceId",
                table: "ServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Status_StatusId",
                table: "ServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequests_PriorityId",
                table: "ServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequests_ServiceId",
                table: "ServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequests_StatusId",
                table: "ServiceRequests");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "ServiceRequests",
                newName: "Priority");

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
    }
}
