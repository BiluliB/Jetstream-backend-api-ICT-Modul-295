using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetstreamApi.Migrations
{
    /// <inheritdoc />
    public partial class addUserAuthentification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

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
        }
    }
}
