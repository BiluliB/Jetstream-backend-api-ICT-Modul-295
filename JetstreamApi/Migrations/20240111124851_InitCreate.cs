using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JetstreamApi.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
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
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
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
                    TotalPrice_CHF = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                columns: new[] { "Id", "IsLocked", "PasswordHash", "PasswordInputAttempt", "PasswordSalt", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, false, new byte[] { 65, 89, 177, 108, 142, 96, 185, 146, 61, 21, 70, 220, 49, 244, 156, 92, 239, 93, 51, 33, 137, 35, 97, 249, 21, 87, 170, 113, 24, 253, 63, 28, 199, 254, 142, 148, 138, 149, 146, 199, 87, 223, 175, 208, 70, 25, 54, 231, 128, 150, 244, 139, 61, 74, 124, 231, 96, 27, 245, 34, 242, 120, 208, 22 }, 0, new byte[] { 32, 180, 186, 22, 208, 138, 208, 177, 111, 201, 207, 57, 201, 37, 186, 6, 139, 2, 104, 193, 160, 159, 14, 111, 55, 180, 231, 248, 33, 37, 116, 215, 5, 89, 38, 229, 16, 194, 196, 50, 11, 179, 241, 224, 137, 149, 15, 165, 217, 232, 53, 20, 143, 55, 222, 202, 87, 109, 164, 42, 207, 179, 42, 195, 195, 5, 197, 95, 36, 163, 235, 58, 57, 61, 77, 156, 150, 102, 238, 130, 60, 192, 7, 206, 93, 253, 164, 136, 118, 224, 78, 94, 35, 13, 159, 196, 51, 63, 176, 94, 205, 206, 96, 96, 137, 56, 211, 75, 2, 179, 92, 223, 77, 214, 16, 53, 4, 96, 31, 154, 77, 220, 77, 106, 210, 112, 83, 245 }, 1, "admin" },
                    { 2, false, new byte[] { 28, 26, 214, 161, 70, 37, 178, 9, 27, 214, 170, 17, 212, 70, 8, 23, 147, 106, 80, 202, 7, 129, 252, 121, 147, 128, 138, 40, 88, 233, 210, 41, 56, 55, 65, 18, 156, 8, 155, 114, 77, 172, 135, 179, 181, 30, 173, 58, 58, 30, 20, 80, 217, 32, 2, 99, 72, 67, 48, 94, 62, 127, 38, 7 }, 0, new byte[] { 179, 38, 91, 31, 49, 18, 20, 233, 8, 142, 251, 21, 28, 81, 154, 22, 154, 209, 234, 163, 104, 179, 120, 56, 221, 171, 140, 195, 162, 23, 66, 134, 182, 181, 85, 108, 128, 173, 0, 150, 95, 90, 188, 49, 22, 109, 239, 250, 29, 72, 175, 119, 180, 86, 44, 88, 105, 108, 33, 75, 79, 237, 118, 243, 78, 46, 243, 249, 220, 96, 103, 171, 90, 54, 230, 146, 239, 133, 114, 28, 198, 21, 246, 88, 83, 253, 246, 46, 205, 98, 87, 45, 71, 125, 224, 70, 185, 215, 108, 1, 162, 94, 186, 231, 182, 135, 63, 37, 34, 24, 199, 174, 163, 25, 234, 97, 99, 36, 230, 181, 172, 17, 190, 241, 95, 70, 198, 246 }, 1, "admin1" },
                    { 3, false, new byte[] { 77, 138, 31, 225, 143, 194, 226, 41, 209, 161, 15, 31, 145, 75, 128, 119, 94, 61, 238, 63, 38, 120, 239, 158, 209, 194, 46, 134, 125, 59, 24, 147, 201, 248, 82, 180, 116, 176, 159, 249, 174, 74, 10, 241, 126, 122, 62, 3, 18, 191, 136, 71, 222, 17, 201, 148, 209, 127, 36, 235, 0, 138, 31, 44 }, 0, new byte[] { 146, 122, 175, 21, 99, 156, 205, 222, 183, 84, 119, 200, 134, 176, 9, 129, 144, 10, 177, 104, 59, 142, 200, 177, 12, 18, 157, 144, 238, 148, 69, 235, 188, 186, 208, 177, 252, 22, 211, 111, 200, 59, 108, 13, 146, 119, 170, 213, 254, 239, 117, 154, 3, 104, 247, 236, 212, 163, 1, 220, 62, 149, 36, 246, 251, 208, 236, 6, 9, 121, 110, 67, 6, 156, 125, 201, 194, 182, 100, 2, 61, 13, 183, 244, 15, 105, 225, 251, 104, 218, 68, 120, 199, 116, 1, 49, 92, 67, 43, 222, 216, 191, 45, 25, 242, 190, 126, 3, 80, 224, 151, 107, 139, 217, 105, 158, 233, 220, 167, 98, 39, 45, 20, 249, 223, 126, 135, 41 }, 0, "user1" },
                    { 4, false, new byte[] { 117, 155, 253, 238, 153, 94, 144, 42, 94, 40, 107, 43, 134, 152, 84, 85, 61, 155, 175, 22, 235, 123, 250, 237, 250, 67, 108, 213, 159, 221, 88, 142, 120, 139, 205, 185, 31, 158, 243, 254, 100, 158, 153, 214, 225, 218, 247, 141, 101, 97, 172, 173, 115, 67, 231, 149, 202, 227, 164, 228, 208, 142, 211, 254 }, 0, new byte[] { 11, 251, 205, 225, 154, 13, 109, 161, 25, 248, 22, 131, 211, 234, 198, 201, 13, 158, 218, 162, 123, 22, 118, 207, 14, 81, 17, 161, 87, 181, 22, 13, 190, 207, 7, 69, 94, 169, 163, 203, 245, 171, 65, 239, 96, 216, 160, 215, 244, 208, 209, 121, 27, 214, 52, 187, 80, 16, 101, 140, 239, 71, 237, 224, 142, 75, 14, 149, 79, 248, 181, 112, 195, 198, 51, 235, 220, 186, 116, 123, 228, 90, 71, 145, 112, 186, 146, 162, 189, 164, 199, 161, 205, 253, 229, 69, 222, 242, 41, 16, 232, 119, 221, 199, 111, 125, 154, 83, 200, 62, 126, 138, 131, 125, 110, 61, 169, 200, 15, 141, 42, 139, 98, 36, 108, 249, 185, 30 }, 0, "user2" },
                    { 5, false, new byte[] { 194, 126, 5, 230, 38, 141, 154, 206, 91, 128, 255, 118, 151, 209, 32, 125, 8, 159, 30, 133, 16, 7, 140, 68, 8, 21, 212, 118, 39, 102, 123, 80, 61, 225, 217, 66, 165, 104, 20, 207, 219, 80, 185, 244, 72, 69, 58, 147, 216, 59, 205, 195, 210, 23, 233, 175, 236, 153, 253, 34, 67, 10, 224, 65 }, 0, new byte[] { 91, 23, 152, 145, 110, 177, 64, 215, 63, 45, 233, 176, 85, 81, 131, 228, 82, 68, 238, 40, 16, 88, 1, 42, 190, 72, 172, 191, 173, 121, 176, 105, 143, 245, 202, 140, 113, 101, 54, 101, 206, 121, 186, 99, 69, 241, 207, 7, 202, 123, 104, 185, 124, 59, 23, 114, 214, 185, 242, 74, 121, 154, 46, 62, 201, 52, 229, 230, 210, 37, 92, 130, 111, 1, 9, 168, 231, 22, 30, 234, 163, 74, 50, 185, 168, 151, 164, 175, 208, 235, 255, 237, 244, 9, 198, 147, 227, 165, 176, 213, 189, 104, 59, 139, 92, 116, 198, 201, 154, 196, 184, 106, 252, 19, 101, 82, 108, 43, 41, 167, 206, 142, 94, 16, 142, 51, 137, 4 }, 0, "user3" },
                    { 6, false, new byte[] { 130, 22, 66, 177, 214, 11, 39, 77, 231, 225, 103, 128, 42, 124, 188, 118, 7, 29, 152, 32, 198, 38, 9, 137, 151, 65, 245, 37, 131, 251, 226, 107, 229, 245, 90, 19, 173, 179, 254, 35, 86, 115, 68, 11, 91, 155, 37, 49, 228, 62, 66, 132, 65, 103, 207, 190, 169, 115, 23, 53, 89, 44, 193, 58 }, 0, new byte[] { 78, 4, 173, 217, 4, 44, 147, 191, 230, 155, 91, 54, 168, 232, 155, 242, 132, 163, 46, 235, 52, 31, 160, 37, 178, 80, 208, 139, 83, 88, 184, 199, 25, 125, 179, 54, 112, 144, 180, 90, 34, 134, 4, 11, 227, 162, 117, 165, 78, 199, 115, 158, 143, 82, 83, 143, 198, 150, 47, 8, 57, 35, 102, 229, 161, 149, 175, 170, 159, 105, 138, 118, 201, 15, 65, 81, 153, 121, 175, 137, 144, 121, 79, 182, 50, 103, 135, 233, 69, 47, 99, 75, 60, 103, 188, 151, 129, 244, 123, 88, 177, 241, 95, 127, 199, 242, 184, 187, 75, 123, 23, 73, 49, 176, 177, 21, 36, 97, 36, 175, 109, 49, 87, 140, 197, 182, 126, 182 }, 0, "user4" },
                    { 7, false, new byte[] { 38, 136, 228, 27, 204, 137, 32, 127, 115, 11, 145, 32, 148, 192, 238, 247, 4, 193, 119, 109, 107, 61, 24, 86, 248, 190, 14, 136, 140, 249, 69, 5, 105, 145, 79, 233, 1, 190, 91, 205, 25, 143, 75, 60, 126, 209, 81, 30, 164, 108, 216, 2, 18, 121, 46, 146, 25, 244, 136, 70, 110, 209, 207, 244 }, 0, new byte[] { 133, 196, 242, 53, 117, 147, 234, 148, 201, 169, 162, 24, 217, 188, 76, 123, 105, 30, 69, 16, 62, 231, 78, 188, 63, 48, 142, 152, 11, 118, 22, 120, 171, 35, 165, 130, 127, 200, 37, 35, 82, 187, 232, 102, 52, 37, 181, 126, 7, 74, 23, 221, 46, 142, 18, 182, 101, 46, 106, 72, 167, 62, 233, 133, 208, 185, 138, 9, 192, 183, 50, 229, 201, 154, 81, 108, 107, 62, 172, 108, 192, 166, 64, 166, 93, 205, 125, 55, 250, 221, 132, 98, 231, 139, 145, 183, 81, 166, 164, 204, 225, 151, 62, 106, 33, 56, 99, 50, 201, 131, 249, 139, 40, 50, 159, 232, 20, 170, 172, 176, 189, 231, 100, 113, 210, 123, 215, 250 }, 0, "user5" },
                    { 8, false, new byte[] { 26, 198, 247, 206, 38, 193, 144, 182, 198, 169, 162, 228, 205, 106, 129, 219, 38, 125, 3, 250, 27, 93, 51, 129, 229, 54, 144, 178, 97, 200, 25, 42, 57, 20, 113, 221, 177, 194, 84, 185, 28, 252, 199, 81, 182, 36, 148, 198, 67, 76, 161, 158, 108, 4, 252, 153, 56, 137, 210, 10, 200, 239, 194, 2 }, 0, new byte[] { 166, 244, 105, 77, 123, 40, 58, 84, 50, 209, 108, 210, 185, 154, 78, 215, 52, 127, 17, 239, 71, 204, 40, 204, 214, 46, 94, 76, 72, 102, 5, 48, 44, 166, 149, 52, 102, 102, 101, 32, 48, 62, 176, 169, 54, 63, 186, 170, 158, 40, 161, 120, 141, 84, 169, 172, 117, 51, 235, 68, 60, 79, 10, 159, 192, 207, 217, 107, 247, 79, 109, 149, 217, 195, 218, 116, 56, 193, 52, 28, 60, 14, 154, 129, 58, 171, 34, 58, 155, 98, 122, 127, 255, 109, 206, 48, 63, 211, 41, 162, 194, 179, 227, 201, 50, 185, 100, 108, 189, 166, 40, 41, 64, 15, 154, 9, 102, 16, 38, 199, 170, 153, 184, 237, 99, 250, 157, 172 }, 0, "user6" },
                    { 9, false, new byte[] { 66, 10, 115, 155, 28, 102, 253, 253, 116, 41, 129, 46, 8, 14, 202, 17, 229, 160, 213, 147, 190, 196, 69, 221, 115, 193, 203, 133, 27, 241, 232, 133, 5, 8, 247, 180, 183, 113, 170, 20, 241, 115, 178, 205, 199, 52, 111, 71, 161, 109, 172, 113, 136, 1, 238, 82, 228, 56, 75, 67, 208, 118, 216, 83 }, 0, new byte[] { 166, 49, 254, 77, 144, 71, 106, 129, 160, 217, 19, 80, 130, 139, 166, 95, 150, 51, 90, 209, 53, 218, 152, 92, 151, 223, 40, 212, 81, 35, 166, 173, 109, 219, 241, 114, 42, 229, 71, 216, 192, 121, 11, 222, 205, 153, 127, 64, 201, 22, 127, 182, 241, 51, 98, 248, 1, 203, 214, 51, 103, 41, 133, 253, 152, 88, 107, 42, 8, 63, 135, 68, 78, 115, 210, 227, 13, 247, 56, 162, 241, 178, 187, 200, 160, 52, 117, 192, 236, 149, 232, 64, 101, 73, 178, 54, 229, 178, 24, 181, 143, 249, 15, 202, 140, 44, 188, 126, 160, 228, 63, 23, 195, 201, 123, 217, 71, 239, 253, 141, 6, 202, 41, 154, 71, 78, 158, 98 }, 0, "user7" },
                    { 10, false, new byte[] { 55, 160, 148, 46, 138, 10, 42, 75, 4, 45, 208, 246, 230, 72, 230, 40, 13, 27, 163, 53, 91, 182, 196, 236, 113, 120, 96, 0, 250, 19, 7, 244, 230, 143, 65, 74, 202, 239, 255, 78, 215, 137, 244, 194, 67, 45, 255, 129, 186, 177, 57, 76, 248, 134, 204, 158, 81, 28, 106, 232, 204, 228, 98, 201 }, 0, new byte[] { 240, 8, 58, 102, 187, 151, 57, 193, 103, 200, 235, 132, 221, 172, 76, 175, 169, 75, 57, 253, 21, 119, 161, 48, 128, 65, 172, 176, 176, 161, 76, 236, 167, 203, 249, 6, 102, 140, 127, 177, 207, 15, 240, 252, 69, 42, 68, 110, 144, 37, 236, 0, 26, 33, 183, 41, 148, 24, 234, 229, 77, 201, 195, 206, 235, 52, 116, 251, 42, 111, 100, 85, 95, 158, 241, 250, 166, 170, 140, 241, 105, 218, 41, 146, 158, 239, 5, 42, 184, 25, 66, 226, 72, 222, 238, 109, 130, 81, 72, 117, 241, 239, 141, 245, 1, 79, 68, 190, 150, 30, 68, 236, 210, 156, 20, 209, 179, 54, 71, 202, 6, 103, 172, 190, 13, 155, 20, 207 }, 0, "user8" },
                    { 11, false, new byte[] { 246, 114, 142, 67, 10, 56, 98, 246, 209, 129, 0, 104, 8, 107, 180, 194, 165, 85, 148, 214, 172, 157, 183, 61, 92, 195, 29, 107, 185, 177, 156, 235, 164, 235, 170, 215, 93, 11, 2, 209, 186, 53, 169, 147, 136, 31, 103, 24, 115, 125, 138, 217, 189, 83, 133, 207, 185, 156, 63, 89, 244, 171, 165, 132 }, 0, new byte[] { 25, 5, 4, 81, 138, 30, 31, 229, 180, 1, 52, 42, 208, 85, 234, 55, 151, 180, 52, 158, 155, 65, 1, 93, 174, 112, 23, 86, 158, 191, 229, 250, 45, 180, 4, 208, 204, 216, 37, 222, 105, 17, 130, 154, 189, 126, 227, 74, 184, 66, 126, 196, 237, 164, 126, 162, 180, 73, 160, 116, 176, 150, 122, 47, 182, 129, 173, 249, 86, 118, 128, 251, 53, 148, 136, 243, 150, 211, 48, 20, 227, 50, 128, 149, 192, 151, 10, 241, 62, 175, 217, 35, 114, 201, 204, 10, 95, 109, 150, 33, 212, 205, 231, 112, 100, 194, 239, 152, 171, 180, 220, 126, 172, 223, 176, 208, 110, 66, 166, 69, 249, 26, 132, 165, 254, 113, 115, 249 }, 0, "user9" },
                    { 12, false, new byte[] { 74, 107, 152, 57, 77, 39, 25, 213, 125, 111, 10, 24, 227, 114, 50, 92, 72, 114, 131, 72, 240, 206, 51, 106, 9, 204, 125, 78, 132, 48, 54, 41, 4, 155, 88, 57, 42, 230, 175, 143, 162, 39, 62, 180, 110, 120, 33, 241, 227, 90, 105, 2, 192, 64, 77, 202, 63, 148, 172, 72, 246, 202, 7, 192 }, 0, new byte[] { 85, 164, 187, 54, 99, 108, 79, 143, 225, 149, 201, 115, 29, 163, 110, 126, 230, 162, 101, 40, 210, 100, 107, 96, 225, 230, 34, 147, 61, 236, 248, 38, 24, 20, 70, 145, 238, 6, 111, 164, 83, 113, 226, 98, 243, 52, 75, 244, 16, 147, 37, 219, 205, 224, 165, 29, 38, 250, 155, 218, 192, 172, 141, 118, 183, 45, 76, 167, 42, 140, 153, 194, 94, 11, 168, 167, 177, 119, 242, 1, 39, 227, 71, 79, 135, 8, 255, 242, 66, 55, 83, 95, 136, 238, 170, 223, 246, 223, 190, 198, 87, 183, 223, 60, 173, 23, 42, 231, 219, 72, 56, 200, 201, 125, 99, 252, 31, 143, 75, 52, 195, 143, 199, 236, 49, 55, 111, 241 }, 0, "user10" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "Comment", "CreateDate", "Email", "Firstname", "Lastname", "Phone", "PickupDate", "PriorityId", "ServiceId", "StatusId", "TotalPrice_CHF", "UserId" },
                values: new object[,]
                {
                    { 1, "Erster Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7688), "max.mustermann@example.com", "Max", "Mustermann", "1234567890", new DateTime(2024, 1, 12, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7733), 1, 1, 1, 49m, null },
                    { 2, "Zweiter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7740), "maria.musterfrau@example.com", "Maria", "Musterfrau", "0987654321", new DateTime(2024, 1, 13, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7741), 3, 2, 2, 79m, null },
                    { 3, "Dritter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7744), "johannes.doe@example.com", "Johannes", "Doe", "1122334455", new DateTime(2024, 1, 14, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7745), 3, 3, 3, 109m, null },
                    { 4, "Vierter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7747), "anna.beispiel@example.com", "Anna", "Beispiel", "2233445566", new DateTime(2024, 1, 15, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7748), 3, 4, 2, 49m, null },
                    { 5, "Fünfter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7751), "lukas.muster@example.com", "Lukas", "Muster", "3344556677", new DateTime(2024, 1, 16, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7752), 2, 5, 1, 30m, null },
                    { 6, "Sechster Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7754), "eva.beispiel@example.com", "Eva", "Beispiel", "4455667788", new DateTime(2024, 1, 17, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7755), 2, 6, 1, 23m, null },
                    { 7, "Siebter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7757), "oliver.müller@example.com", "Oliver", "Müller", "5566778899", new DateTime(2024, 1, 18, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7758), 1, 1, 2, 49m, null },
                    { 8, "Achter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7761), "sophia.schmidt@example.com", "Sophia", "Schmidt", "6677889900", new DateTime(2024, 1, 19, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7762), 3, 2, 3, 79m, null },
                    { 9, "Neunter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7764), "felix.schneider@example.com", "Felix", "Schneider", "7788990011", new DateTime(2024, 1, 20, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7765), 1, 4, 1, 39m, null },
                    { 10, "Zehnter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7768), "laura.fischer@example.com", "Laura", "Fischer", "8899001122", new DateTime(2024, 1, 21, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7769), 2, 5, 2, 30m, null },
                    { 11, "Elfter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7771), "maximilian.weber@example.com", "Maximilian", "Weber", "9900112233", new DateTime(2024, 1, 22, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7772), 3, 1, 3, 59m, null },
                    { 12, "Zwölfter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7774), "hannah.meier@example.com", "Hannah", "Meier", "9911223344", new DateTime(2024, 1, 23, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7775), 1, 3, 1, 99m, null },
                    { 13, "Dreizehnter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7778), "leon.wagner@example.com", "Leon", "Wagner", "9922334455", new DateTime(2024, 1, 24, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7779), 2, 2, 2, 74m, null },
                    { 14, "Vierzehnter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7781), "emily.becker@example.com", "Emily", "Becker", "9933445566", new DateTime(2024, 1, 25, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7782), 3, 4, 3, 49m, null },
                    { 15, "Fünfzehnter Kommentar", new DateTime(2024, 1, 11, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7784), "noah.hoffmann@example.com", "Noah", "Hoffmann", "9944556677", new DateTime(2024, 1, 26, 13, 48, 50, 977, DateTimeKind.Local).AddTicks(7785), 1, 5, 1, 25m, null }
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
