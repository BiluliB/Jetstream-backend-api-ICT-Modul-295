using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JetstreamApi.Migrations
{
    /// <inheritdoc />
    public partial class initialCreat : Migration
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
                    PriorityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    ServiceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordInputAttempt = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Price", "PriorityName" },
                values: new object[,]
                {
                    { 1, 0m, "Tief" },
                    { 2, 5m, "Standard" },
                    { 3, 10m, "Hoch" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, 49m, "Kleiner Service" },
                    { 2, 69m, "Großer Service" },
                    { 3, 99m, "Rennskiservice" },
                    { 4, 39m, "Bindung montieren und einstellen" },
                    { 5, 25m, "Fell zuschneiden" },
                    { 6, 18m, "Heißwachsen" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Offen" },
                    { 2, "In Arbeit" },
                    { 3, "Abgeschlossen" },
                    { 4, "Storniert" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsLocked", "PasswordHash", "PasswordInputAttempt", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { 1, false, new byte[] { 74, 34, 37, 128, 216, 170, 248, 197, 129, 121, 20, 158, 68, 112, 234, 106, 234, 46, 100, 203, 143, 217, 188, 5, 156, 138, 90, 155, 50, 129, 150, 209, 65, 176, 217, 217, 56, 212, 157, 187, 83, 43, 239, 142, 17, 238, 114, 114, 123, 248, 242, 81, 145, 115, 108, 148, 133, 36, 78, 208, 180, 216, 153, 90 }, 0, new byte[] { 134, 70, 11, 255, 87, 148, 125, 43, 74, 46, 87, 107, 47, 203, 40, 253, 205, 208, 164, 240, 122, 211, 141, 242, 72, 102, 250, 40, 70, 124, 153, 254, 167, 73, 167, 244, 156, 40, 18, 113, 2, 123, 206, 113, 236, 29, 218, 3, 113, 166, 189, 218, 188, 212, 0, 27, 129, 176, 182, 189, 105, 104, 178, 17, 206, 71, 254, 121, 127, 124, 129, 179, 124, 147, 176, 29, 134, 119, 58, 152, 53, 55, 103, 18, 166, 80, 246, 237, 4, 250, 123, 42, 109, 124, 83, 235, 64, 192, 236, 52, 108, 39, 15, 9, 23, 72, 241, 62, 171, 52, 236, 198, 22, 252, 88, 222, 49, 250, 47, 189, 248, 246, 134, 229, 134, 21, 25, 93 }, "user1" },
                    { 2, false, new byte[] { 67, 241, 62, 206, 104, 70, 4, 180, 121, 18, 105, 254, 105, 111, 233, 162, 210, 48, 146, 237, 38, 153, 25, 194, 252, 239, 216, 2, 226, 137, 179, 182, 141, 208, 208, 75, 71, 52, 76, 246, 41, 157, 252, 113, 140, 137, 122, 6, 45, 85, 47, 160, 142, 91, 144, 108, 16, 201, 122, 116, 145, 8, 131, 154 }, 0, new byte[] { 44, 84, 176, 182, 156, 6, 83, 229, 120, 202, 243, 83, 134, 108, 183, 148, 89, 208, 98, 83, 164, 118, 84, 50, 106, 14, 70, 157, 199, 187, 232, 199, 177, 47, 38, 137, 160, 86, 199, 164, 24, 245, 227, 51, 145, 102, 70, 81, 248, 45, 111, 10, 12, 100, 232, 124, 128, 177, 194, 120, 234, 6, 172, 56, 23, 132, 51, 186, 200, 67, 122, 147, 222, 223, 209, 167, 237, 222, 2, 110, 197, 86, 233, 106, 75, 65, 243, 245, 21, 87, 2, 40, 200, 142, 6, 69, 60, 200, 18, 11, 242, 155, 90, 169, 133, 152, 210, 142, 211, 68, 146, 159, 97, 135, 186, 254, 7, 6, 221, 14, 224, 4, 250, 132, 99, 8, 216, 221 }, "user2" },
                    { 3, false, new byte[] { 4, 253, 197, 188, 26, 100, 68, 194, 3, 162, 36, 139, 85, 131, 208, 136, 43, 205, 199, 221, 245, 39, 205, 221, 201, 115, 91, 248, 156, 110, 154, 93, 216, 162, 139, 37, 95, 253, 179, 30, 107, 178, 35, 78, 17, 215, 10, 32, 110, 226, 129, 151, 132, 185, 95, 207, 133, 191, 67, 219, 130, 182, 35, 206 }, 0, new byte[] { 205, 97, 87, 227, 227, 125, 235, 173, 176, 19, 243, 219, 235, 60, 150, 131, 206, 211, 142, 242, 222, 131, 87, 132, 182, 189, 231, 107, 169, 92, 61, 56, 147, 71, 109, 87, 112, 147, 131, 230, 50, 87, 200, 131, 124, 13, 95, 198, 14, 59, 68, 222, 125, 214, 11, 225, 247, 175, 33, 219, 244, 20, 0, 48, 47, 102, 78, 207, 34, 84, 74, 253, 38, 133, 178, 30, 220, 147, 242, 216, 153, 173, 63, 53, 136, 170, 81, 240, 17, 221, 32, 122, 40, 187, 145, 105, 164, 78, 56, 237, 186, 156, 2, 4, 160, 103, 172, 140, 213, 6, 108, 139, 20, 213, 227, 106, 157, 34, 176, 143, 232, 37, 77, 128, 23, 100, 170, 203 }, "user3" },
                    { 4, false, new byte[] { 16, 142, 195, 56, 182, 125, 165, 43, 161, 31, 19, 58, 98, 58, 102, 6, 18, 43, 198, 94, 195, 12, 159, 209, 157, 61, 105, 212, 111, 105, 107, 17, 123, 184, 194, 69, 134, 130, 52, 85, 159, 95, 188, 172, 92, 123, 240, 150, 118, 166, 3, 21, 165, 44, 94, 38, 78, 201, 232, 50, 235, 90, 14, 132 }, 0, new byte[] { 89, 80, 212, 85, 196, 195, 72, 155, 57, 153, 239, 42, 98, 2, 84, 124, 88, 76, 89, 82, 112, 149, 148, 120, 73, 161, 40, 47, 38, 43, 141, 29, 203, 106, 244, 130, 54, 58, 177, 73, 221, 60, 11, 11, 4, 89, 188, 17, 15, 176, 236, 211, 64, 8, 167, 101, 190, 156, 160, 46, 128, 158, 169, 54, 91, 241, 59, 246, 252, 254, 163, 1, 199, 125, 164, 61, 221, 36, 76, 89, 69, 242, 162, 230, 17, 102, 180, 219, 66, 42, 83, 119, 51, 107, 211, 196, 178, 14, 10, 223, 146, 252, 88, 109, 121, 194, 226, 7, 244, 157, 166, 198, 22, 83, 241, 28, 204, 85, 148, 82, 229, 0, 252, 104, 129, 79, 248, 3 }, "user4" },
                    { 5, false, new byte[] { 92, 251, 174, 159, 227, 219, 3, 73, 164, 181, 240, 45, 53, 62, 26, 96, 211, 203, 203, 122, 253, 196, 107, 124, 136, 242, 215, 43, 29, 222, 11, 168, 210, 52, 66, 246, 165, 36, 23, 157, 66, 45, 220, 94, 149, 236, 181, 245, 154, 166, 164, 153, 117, 200, 130, 143, 123, 82, 235, 241, 184, 160, 3, 152 }, 0, new byte[] { 71, 213, 163, 4, 196, 184, 108, 112, 115, 121, 233, 4, 34, 222, 125, 45, 2, 75, 30, 229, 147, 29, 84, 92, 40, 52, 127, 175, 190, 65, 219, 39, 75, 241, 57, 213, 33, 217, 164, 241, 146, 92, 114, 62, 129, 248, 43, 34, 173, 9, 60, 232, 184, 217, 171, 224, 98, 204, 56, 182, 139, 200, 52, 245, 242, 89, 159, 8, 113, 56, 139, 250, 208, 27, 168, 8, 29, 22, 112, 190, 110, 24, 100, 186, 103, 151, 15, 81, 17, 129, 189, 120, 59, 93, 204, 46, 122, 35, 5, 162, 124, 117, 148, 53, 187, 254, 124, 162, 228, 2, 194, 112, 92, 197, 8, 220, 237, 73, 195, 245, 165, 226, 102, 74, 113, 247, 6, 158 }, "user5" },
                    { 6, false, new byte[] { 223, 85, 4, 49, 148, 57, 69, 220, 119, 150, 6, 15, 213, 54, 33, 216, 4, 190, 38, 202, 82, 178, 50, 15, 230, 241, 93, 30, 81, 197, 47, 126, 22, 241, 58, 217, 117, 233, 228, 235, 38, 33, 218, 43, 191, 127, 190, 245, 85, 182, 15, 227, 20, 34, 173, 112, 92, 116, 254, 54, 165, 150, 1, 118 }, 0, new byte[] { 225, 137, 17, 62, 241, 233, 155, 247, 183, 204, 69, 148, 38, 100, 17, 121, 252, 139, 23, 136, 82, 68, 177, 45, 29, 189, 83, 149, 64, 57, 231, 114, 72, 136, 160, 95, 178, 133, 0, 131, 195, 64, 131, 206, 200, 71, 194, 145, 193, 170, 232, 82, 106, 106, 196, 12, 147, 172, 246, 77, 56, 25, 117, 131, 224, 3, 76, 3, 175, 184, 192, 117, 226, 43, 81, 51, 127, 123, 136, 151, 48, 143, 110, 142, 218, 72, 111, 221, 31, 81, 81, 136, 83, 24, 240, 198, 181, 164, 140, 113, 12, 69, 104, 229, 141, 131, 163, 182, 104, 134, 186, 107, 136, 52, 243, 139, 113, 98, 83, 33, 34, 127, 126, 72, 253, 3, 229, 197 }, "user6" },
                    { 7, false, new byte[] { 237, 69, 115, 115, 198, 107, 22, 136, 153, 55, 79, 47, 102, 190, 105, 184, 127, 90, 194, 28, 176, 171, 107, 58, 251, 123, 152, 252, 169, 91, 237, 32, 206, 195, 150, 48, 14, 225, 107, 184, 242, 24, 24, 212, 25, 103, 146, 134, 227, 77, 72, 78, 78, 44, 153, 100, 224, 89, 61, 10, 242, 42, 115, 250 }, 0, new byte[] { 247, 250, 92, 35, 120, 63, 13, 173, 246, 162, 219, 128, 119, 79, 21, 114, 70, 2, 150, 167, 236, 24, 77, 158, 162, 199, 81, 188, 4, 26, 157, 228, 18, 153, 78, 175, 25, 25, 65, 39, 55, 175, 76, 3, 74, 4, 50, 244, 243, 123, 6, 237, 208, 51, 97, 43, 155, 184, 85, 160, 131, 178, 170, 139, 194, 62, 121, 187, 185, 13, 48, 118, 71, 252, 104, 109, 138, 192, 86, 148, 161, 223, 139, 114, 109, 27, 183, 38, 124, 192, 121, 225, 78, 78, 137, 16, 35, 237, 112, 235, 109, 251, 137, 220, 192, 246, 21, 171, 227, 211, 23, 236, 254, 147, 171, 9, 121, 214, 210, 162, 172, 9, 88, 236, 246, 71, 56, 174 }, "user7" },
                    { 8, false, new byte[] { 170, 192, 53, 92, 120, 68, 104, 126, 45, 86, 87, 179, 192, 81, 72, 26, 82, 108, 125, 88, 228, 207, 212, 163, 236, 35, 160, 40, 113, 157, 39, 212, 121, 143, 84, 54, 221, 81, 183, 60, 113, 85, 179, 110, 254, 82, 35, 203, 219, 139, 178, 161, 194, 37, 94, 160, 130, 174, 70, 71, 45, 62, 207, 35 }, 0, new byte[] { 155, 145, 176, 172, 220, 161, 46, 185, 160, 127, 33, 219, 56, 169, 163, 27, 12, 121, 154, 252, 76, 41, 62, 157, 76, 0, 81, 223, 78, 122, 239, 116, 91, 189, 4, 229, 228, 140, 195, 27, 227, 49, 121, 0, 83, 26, 128, 63, 27, 161, 20, 49, 30, 123, 198, 100, 23, 90, 48, 252, 116, 248, 195, 99, 209, 115, 212, 130, 219, 22, 22, 114, 184, 200, 90, 64, 113, 164, 56, 69, 182, 86, 123, 84, 160, 118, 220, 15, 37, 62, 4, 243, 181, 51, 202, 134, 130, 101, 148, 154, 176, 124, 177, 115, 193, 71, 82, 27, 106, 24, 44, 72, 44, 42, 65, 103, 151, 40, 59, 63, 156, 21, 117, 65, 54, 7, 114, 184 }, "user8" },
                    { 9, false, new byte[] { 26, 107, 143, 18, 212, 81, 208, 47, 158, 200, 152, 113, 115, 41, 193, 147, 7, 13, 159, 252, 185, 228, 144, 55, 154, 127, 13, 118, 140, 17, 213, 172, 118, 149, 137, 49, 58, 180, 188, 103, 17, 251, 255, 139, 183, 93, 233, 5, 9, 143, 132, 250, 105, 247, 151, 107, 212, 40, 222, 237, 199, 113, 125, 240 }, 0, new byte[] { 118, 51, 207, 214, 39, 109, 48, 110, 118, 163, 18, 1, 37, 182, 206, 218, 26, 219, 251, 27, 137, 42, 250, 10, 191, 120, 53, 144, 83, 206, 44, 215, 78, 25, 98, 227, 3, 228, 35, 151, 214, 177, 206, 149, 230, 115, 24, 85, 248, 178, 204, 11, 228, 144, 10, 246, 13, 165, 45, 213, 140, 243, 14, 251, 244, 122, 193, 105, 99, 7, 120, 81, 120, 2, 197, 195, 78, 36, 95, 95, 77, 50, 13, 215, 212, 209, 56, 149, 82, 219, 61, 23, 253, 82, 99, 30, 76, 137, 237, 3, 248, 120, 28, 63, 188, 2, 231, 39, 53, 48, 63, 6, 249, 142, 86, 44, 94, 17, 9, 145, 165, 126, 2, 122, 247, 6, 42, 250 }, "user9" },
                    { 10, false, new byte[] { 44, 41, 211, 229, 76, 90, 193, 207, 204, 124, 173, 211, 165, 8, 181, 185, 126, 203, 34, 236, 62, 74, 78, 212, 163, 64, 33, 128, 252, 228, 111, 103, 219, 197, 101, 29, 26, 147, 227, 216, 206, 102, 78, 145, 15, 153, 248, 170, 208, 138, 123, 171, 178, 100, 192, 65, 179, 228, 212, 6, 182, 114, 7, 123 }, 0, new byte[] { 108, 16, 187, 73, 15, 57, 243, 138, 118, 72, 170, 36, 183, 134, 228, 249, 71, 214, 55, 139, 128, 89, 181, 71, 66, 133, 135, 89, 70, 244, 205, 166, 73, 150, 233, 22, 63, 241, 209, 194, 136, 68, 215, 156, 163, 136, 154, 73, 95, 128, 71, 14, 23, 202, 175, 125, 208, 23, 67, 150, 172, 66, 240, 183, 82, 7, 239, 124, 81, 208, 244, 225, 134, 75, 188, 173, 155, 243, 216, 54, 235, 163, 1, 212, 88, 163, 8, 82, 126, 53, 162, 6, 95, 252, 198, 87, 114, 9, 64, 165, 182, 149, 52, 117, 152, 208, 119, 212, 118, 185, 91, 162, 142, 255, 168, 35, 223, 60, 135, 238, 119, 21, 121, 128, 231, 82, 7, 222 }, "user10" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "Comment", "CreateDate", "Email", "Firstname", "Lastname", "Phone", "PickupDate", "PriorityId", "ServiceId", "StatusId", "UserId" },
                values: new object[,]
                {
                    { 1, "Erster Kommentar", new DateTime(2023, 11, 21, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2073), "max.mustermann@example.com", "Max", "Mustermann", "1234567890", new DateTime(2023, 11, 22, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2120), 1, 1, 1, null },
                    { 2, "Zweiter Kommentar", new DateTime(2023, 11, 21, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2126), "maria.musterfrau@example.com", "Maria", "Musterfrau", "0987654321", new DateTime(2023, 11, 23, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2127), 3, 2, 2, null },
                    { 3, "Dritter Kommentar", new DateTime(2023, 11, 21, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2129), "johannes.doe@example.com", "Johannes", "Doe", "1122334455", new DateTime(2023, 11, 24, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2130), 3, 3, 3, null },
                    { 4, "Vierter Kommentar", new DateTime(2023, 11, 21, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2132), "anna.beispiel@example.com", "Anna", "Beispiel", "2233445566", new DateTime(2023, 11, 25, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2133), 3, 4, 2, null },
                    { 5, "Fünfter Kommentar", new DateTime(2023, 11, 21, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2135), "lukas.muster@example.com", "Lukas", "Muster", "3344556677", new DateTime(2023, 11, 26, 19, 29, 17, 804, DateTimeKind.Local).AddTicks(2136), 2, 5, 1, null }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_UserId",
                table: "ServiceRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
