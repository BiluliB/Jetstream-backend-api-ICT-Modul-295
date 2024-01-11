﻿using System;
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
                    { 1, false, new byte[] { 239, 195, 90, 69, 3, 25, 230, 54, 145, 35, 204, 195, 130, 134, 136, 161, 197, 210, 22, 83, 136, 142, 130, 201, 91, 211, 171, 136, 41, 66, 23, 233, 141, 163, 209, 15, 91, 164, 83, 233, 3, 45, 133, 62, 214, 15, 201, 143, 201, 191, 215, 148, 99, 158, 150, 177, 42, 220, 24, 85, 161, 11, 169, 137 }, 0, new byte[] { 40, 152, 92, 4, 65, 66, 194, 3, 106, 106, 42, 251, 149, 86, 202, 82, 193, 63, 165, 187, 43, 146, 96, 138, 120, 12, 52, 149, 114, 84, 43, 19, 4, 39, 63, 132, 241, 152, 3, 141, 227, 239, 141, 85, 169, 73, 76, 5, 79, 241, 57, 14, 123, 184, 121, 153, 128, 166, 228, 209, 104, 144, 23, 88, 209, 237, 75, 174, 126, 230, 229, 80, 202, 50, 53, 89, 158, 252, 148, 205, 14, 137, 134, 242, 124, 72, 56, 30, 118, 57, 159, 86, 87, 71, 207, 98, 42, 227, 151, 179, 203, 132, 83, 97, 54, 169, 235, 215, 65, 227, 227, 122, 254, 49, 5, 17, 141, 121, 24, 52, 205, 126, 238, 202, 204, 193, 125, 71 }, 1, "admin" },
                    { 2, false, new byte[] { 133, 181, 145, 79, 27, 181, 70, 91, 239, 89, 4, 78, 108, 46, 221, 165, 241, 46, 58, 46, 224, 184, 148, 144, 60, 1, 222, 239, 37, 61, 218, 115, 15, 101, 14, 70, 238, 94, 220, 51, 241, 71, 202, 99, 140, 108, 50, 48, 92, 207, 187, 22, 145, 177, 200, 17, 242, 5, 227, 192, 208, 191, 229, 245 }, 0, new byte[] { 203, 114, 86, 19, 118, 228, 163, 143, 34, 48, 104, 192, 70, 230, 5, 80, 187, 59, 174, 121, 169, 178, 235, 33, 254, 157, 240, 13, 96, 38, 41, 77, 235, 48, 70, 148, 20, 111, 84, 31, 8, 148, 50, 199, 147, 109, 189, 153, 22, 72, 235, 111, 217, 106, 74, 211, 36, 133, 169, 186, 232, 191, 60, 34, 212, 111, 237, 121, 18, 133, 180, 30, 225, 219, 191, 128, 83, 224, 76, 19, 245, 91, 171, 160, 190, 46, 72, 47, 79, 55, 153, 80, 210, 178, 95, 242, 188, 9, 129, 222, 5, 196, 195, 194, 104, 12, 79, 10, 210, 29, 91, 8, 124, 81, 53, 95, 252, 193, 0, 205, 85, 55, 53, 48, 242, 148, 16, 227 }, 1, "admin1" },
                    { 3, false, new byte[] { 250, 57, 80, 157, 90, 203, 117, 39, 39, 218, 172, 5, 119, 252, 131, 83, 8, 200, 252, 10, 141, 80, 171, 253, 124, 167, 12, 190, 178, 129, 144, 254, 230, 38, 102, 190, 44, 185, 104, 22, 160, 214, 106, 21, 187, 20, 246, 207, 67, 176, 63, 109, 126, 210, 145, 187, 164, 84, 128, 47, 42, 60, 55, 74 }, 0, new byte[] { 219, 147, 57, 231, 121, 250, 60, 224, 111, 208, 253, 110, 59, 165, 210, 203, 229, 150, 57, 39, 10, 44, 158, 152, 132, 100, 210, 179, 238, 72, 110, 229, 120, 228, 248, 88, 150, 126, 198, 207, 146, 0, 251, 90, 82, 74, 150, 222, 101, 35, 186, 122, 166, 78, 47, 217, 176, 1, 226, 62, 169, 37, 27, 123, 190, 101, 160, 2, 108, 249, 229, 236, 252, 190, 56, 88, 138, 79, 108, 184, 150, 34, 170, 123, 15, 177, 228, 148, 66, 225, 139, 117, 103, 36, 98, 104, 185, 10, 2, 233, 139, 18, 145, 17, 223, 181, 6, 76, 187, 140, 202, 89, 2, 161, 65, 241, 196, 243, 109, 18, 204, 74, 102, 68, 84, 104, 91, 70 }, 0, "user1" },
                    { 4, false, new byte[] { 116, 126, 94, 174, 109, 76, 150, 184, 77, 254, 197, 112, 89, 52, 75, 210, 64, 125, 24, 201, 76, 37, 1, 249, 196, 44, 227, 0, 230, 0, 183, 47, 155, 60, 215, 146, 115, 174, 220, 136, 30, 94, 120, 93, 135, 4, 106, 197, 194, 43, 107, 194, 225, 116, 114, 140, 175, 169, 97, 95, 64, 167, 159, 29 }, 0, new byte[] { 239, 178, 220, 137, 213, 171, 141, 38, 137, 56, 25, 32, 164, 253, 86, 178, 28, 162, 62, 45, 157, 97, 115, 50, 91, 234, 190, 15, 29, 47, 210, 104, 152, 52, 123, 39, 197, 24, 104, 38, 24, 242, 158, 20, 229, 233, 158, 85, 67, 226, 223, 52, 110, 121, 117, 30, 98, 181, 180, 19, 210, 38, 179, 77, 145, 58, 243, 27, 160, 131, 192, 10, 56, 211, 229, 42, 239, 37, 52, 80, 202, 188, 122, 50, 150, 5, 155, 192, 60, 233, 152, 96, 159, 31, 109, 189, 62, 86, 102, 65, 11, 179, 129, 15, 119, 107, 254, 15, 94, 13, 196, 91, 173, 114, 131, 242, 31, 50, 179, 160, 105, 116, 240, 80, 203, 181, 198, 163 }, 0, "user2" },
                    { 5, false, new byte[] { 61, 37, 251, 106, 117, 157, 210, 77, 46, 194, 222, 40, 52, 106, 67, 6, 199, 237, 29, 128, 109, 96, 16, 214, 161, 64, 16, 208, 177, 177, 160, 98, 251, 166, 114, 112, 137, 158, 95, 102, 147, 88, 168, 151, 171, 242, 91, 38, 61, 255, 142, 129, 178, 132, 252, 109, 237, 194, 53, 102, 34, 234, 45, 115 }, 0, new byte[] { 163, 247, 161, 98, 2, 85, 85, 216, 135, 171, 165, 218, 17, 79, 51, 231, 139, 77, 153, 231, 120, 114, 125, 206, 202, 100, 63, 74, 177, 152, 93, 133, 103, 207, 83, 24, 249, 170, 149, 62, 84, 124, 121, 138, 88, 220, 136, 18, 236, 82, 112, 236, 46, 226, 158, 114, 55, 220, 9, 134, 240, 114, 236, 22, 159, 118, 231, 3, 65, 64, 10, 208, 65, 49, 7, 155, 14, 143, 104, 4, 23, 208, 206, 96, 90, 203, 96, 59, 43, 157, 251, 207, 123, 247, 163, 75, 98, 186, 42, 193, 125, 126, 29, 174, 185, 153, 122, 146, 66, 97, 4, 202, 172, 133, 19, 125, 221, 32, 156, 186, 52, 165, 71, 238, 68, 97, 45, 122 }, 0, "user3" },
                    { 6, false, new byte[] { 170, 51, 132, 208, 124, 234, 254, 18, 102, 131, 176, 86, 115, 134, 129, 1, 183, 251, 252, 209, 26, 251, 225, 26, 150, 143, 164, 181, 220, 24, 73, 138, 121, 216, 131, 76, 194, 247, 116, 195, 17, 146, 69, 153, 242, 161, 142, 141, 86, 89, 196, 51, 57, 108, 59, 184, 243, 148, 247, 211, 215, 210, 184, 216 }, 0, new byte[] { 91, 102, 148, 209, 225, 192, 121, 80, 183, 203, 36, 125, 38, 208, 149, 46, 227, 239, 202, 179, 57, 73, 42, 238, 207, 91, 140, 58, 154, 26, 18, 159, 203, 34, 162, 196, 254, 148, 77, 196, 90, 144, 170, 254, 17, 90, 147, 90, 82, 233, 20, 195, 84, 159, 71, 151, 243, 13, 238, 28, 71, 237, 63, 142, 45, 187, 230, 68, 60, 50, 129, 35, 221, 90, 174, 26, 48, 52, 241, 251, 191, 24, 113, 108, 249, 45, 4, 66, 42, 170, 94, 68, 56, 73, 208, 208, 141, 91, 131, 250, 124, 76, 166, 247, 102, 71, 151, 175, 117, 247, 173, 131, 81, 17, 136, 20, 19, 252, 207, 159, 113, 83, 88, 218, 174, 32, 124, 126 }, 0, "user4" },
                    { 7, false, new byte[] { 82, 207, 123, 250, 227, 179, 166, 44, 233, 243, 38, 41, 66, 164, 212, 220, 167, 190, 96, 26, 94, 97, 255, 153, 151, 41, 149, 222, 228, 192, 250, 225, 19, 53, 35, 55, 61, 211, 98, 224, 138, 174, 139, 238, 223, 163, 247, 134, 180, 229, 216, 118, 64, 134, 45, 147, 13, 72, 240, 82, 217, 86, 232, 241 }, 0, new byte[] { 127, 250, 39, 64, 58, 240, 225, 238, 152, 238, 70, 26, 172, 79, 90, 99, 20, 130, 206, 141, 23, 253, 236, 7, 55, 128, 38, 39, 251, 236, 222, 163, 214, 24, 49, 230, 232, 149, 242, 141, 254, 29, 165, 162, 64, 153, 72, 69, 76, 243, 206, 168, 50, 192, 207, 221, 80, 12, 101, 6, 250, 214, 67, 31, 168, 110, 23, 217, 100, 38, 138, 40, 94, 126, 55, 220, 112, 198, 29, 193, 182, 157, 46, 69, 111, 23, 131, 21, 9, 171, 19, 121, 223, 148, 203, 227, 215, 196, 64, 55, 80, 119, 231, 120, 128, 12, 31, 65, 63, 70, 231, 231, 57, 31, 145, 115, 206, 30, 234, 236, 231, 98, 247, 21, 14, 186, 20, 47 }, 0, "user5" },
                    { 8, false, new byte[] { 191, 13, 41, 227, 196, 70, 123, 248, 65, 152, 39, 98, 59, 66, 111, 153, 191, 105, 57, 29, 104, 68, 126, 111, 104, 160, 107, 227, 44, 245, 65, 50, 241, 119, 55, 170, 121, 135, 100, 188, 25, 251, 136, 173, 21, 165, 47, 107, 212, 122, 227, 210, 148, 225, 241, 244, 206, 252, 199, 27, 81, 103, 243, 139 }, 0, new byte[] { 152, 203, 185, 135, 158, 38, 139, 138, 34, 194, 51, 109, 128, 59, 91, 132, 171, 57, 141, 225, 76, 58, 208, 36, 221, 208, 178, 40, 250, 147, 122, 129, 135, 42, 250, 65, 247, 183, 86, 73, 45, 68, 44, 253, 238, 11, 175, 68, 32, 12, 31, 50, 194, 21, 129, 128, 129, 102, 232, 170, 24, 66, 74, 68, 219, 209, 156, 210, 80, 227, 150, 133, 42, 192, 248, 46, 182, 213, 19, 86, 98, 206, 233, 149, 166, 13, 96, 37, 228, 237, 91, 202, 106, 97, 206, 146, 208, 70, 187, 243, 16, 49, 50, 76, 165, 86, 177, 26, 41, 17, 223, 148, 30, 206, 53, 148, 36, 240, 88, 10, 116, 169, 141, 93, 59, 223, 145, 87 }, 0, "user6" },
                    { 9, false, new byte[] { 68, 132, 1, 87, 121, 102, 235, 155, 252, 56, 255, 33, 13, 175, 27, 79, 171, 235, 52, 221, 67, 92, 100, 112, 26, 219, 114, 77, 189, 176, 196, 141, 223, 2, 75, 254, 137, 36, 197, 119, 40, 147, 96, 235, 61, 221, 194, 37, 129, 220, 157, 28, 200, 25, 187, 208, 235, 59, 194, 94, 92, 119, 22, 185 }, 0, new byte[] { 95, 175, 163, 240, 149, 60, 237, 156, 97, 133, 162, 95, 85, 190, 84, 186, 38, 142, 40, 253, 32, 116, 179, 217, 241, 150, 10, 254, 247, 222, 100, 5, 214, 98, 29, 149, 171, 206, 120, 144, 12, 76, 219, 83, 194, 183, 64, 220, 217, 206, 170, 111, 15, 24, 144, 238, 25, 151, 84, 5, 71, 254, 185, 157, 12, 11, 147, 82, 102, 128, 101, 85, 89, 114, 111, 131, 178, 25, 14, 234, 152, 130, 105, 123, 130, 55, 128, 237, 174, 198, 214, 37, 59, 173, 35, 115, 161, 199, 152, 97, 218, 155, 111, 25, 87, 122, 210, 21, 156, 119, 79, 174, 198, 36, 239, 116, 27, 240, 40, 153, 212, 244, 19, 144, 17, 165, 100, 174 }, 0, "user7" },
                    { 10, false, new byte[] { 79, 70, 44, 71, 115, 142, 223, 65, 199, 74, 24, 53, 161, 249, 42, 243, 161, 169, 45, 172, 34, 126, 152, 181, 240, 150, 8, 200, 84, 193, 83, 204, 114, 142, 179, 78, 192, 29, 90, 16, 101, 4, 70, 216, 86, 68, 90, 65, 52, 87, 25, 126, 86, 200, 116, 159, 46, 6, 189, 221, 138, 214, 156, 0 }, 0, new byte[] { 214, 173, 4, 198, 13, 234, 108, 162, 84, 200, 196, 101, 39, 34, 40, 247, 81, 185, 187, 224, 72, 115, 31, 191, 101, 144, 171, 179, 229, 26, 213, 2, 41, 45, 29, 89, 172, 189, 5, 14, 226, 131, 77, 99, 13, 60, 194, 200, 48, 122, 31, 85, 198, 5, 72, 49, 23, 112, 170, 145, 150, 94, 93, 174, 83, 177, 208, 197, 169, 240, 72, 207, 125, 236, 164, 73, 53, 162, 37, 94, 182, 203, 174, 195, 165, 106, 204, 195, 6, 186, 146, 131, 208, 128, 171, 38, 208, 28, 176, 157, 162, 158, 236, 108, 165, 44, 36, 17, 62, 75, 45, 160, 232, 179, 207, 243, 205, 45, 36, 233, 127, 249, 182, 154, 55, 47, 171, 248 }, 0, "user8" },
                    { 11, false, new byte[] { 93, 92, 216, 119, 2, 100, 211, 241, 106, 137, 193, 128, 134, 120, 195, 79, 49, 95, 153, 69, 143, 223, 209, 195, 67, 209, 177, 127, 209, 151, 59, 86, 220, 215, 180, 94, 39, 0, 153, 148, 2, 160, 106, 35, 171, 139, 255, 251, 52, 219, 52, 37, 95, 145, 200, 128, 132, 48, 78, 194, 6, 156, 82, 139 }, 0, new byte[] { 24, 4, 150, 63, 154, 106, 62, 43, 77, 99, 222, 146, 252, 253, 106, 215, 62, 208, 95, 213, 112, 150, 198, 28, 149, 110, 169, 34, 173, 124, 44, 45, 144, 103, 97, 129, 69, 126, 240, 81, 121, 73, 32, 115, 39, 99, 235, 129, 36, 173, 189, 1, 250, 206, 73, 57, 125, 46, 192, 169, 203, 58, 241, 19, 150, 160, 192, 159, 180, 140, 253, 95, 70, 163, 243, 73, 195, 214, 217, 67, 168, 193, 161, 217, 157, 91, 2, 45, 211, 31, 71, 225, 112, 69, 73, 116, 134, 86, 140, 114, 87, 88, 26, 243, 73, 3, 186, 6, 8, 234, 79, 145, 6, 143, 160, 186, 144, 110, 127, 125, 212, 186, 231, 162, 219, 247, 109, 80 }, 0, "user9" },
                    { 12, false, new byte[] { 154, 29, 179, 109, 79, 189, 161, 25, 135, 194, 168, 65, 115, 132, 191, 55, 186, 245, 72, 24, 49, 176, 107, 206, 216, 101, 73, 38, 66, 99, 149, 185, 20, 232, 153, 198, 68, 16, 84, 178, 45, 58, 77, 195, 8, 204, 249, 98, 173, 240, 222, 162, 246, 95, 159, 72, 205, 0, 169, 187, 184, 6, 171, 228 }, 0, new byte[] { 197, 54, 134, 181, 194, 202, 90, 180, 244, 242, 108, 165, 2, 33, 22, 124, 239, 56, 53, 76, 31, 182, 155, 145, 169, 208, 124, 182, 49, 5, 105, 38, 102, 21, 151, 253, 155, 229, 6, 213, 44, 216, 80, 106, 17, 181, 102, 128, 8, 134, 182, 57, 70, 6, 14, 2, 108, 197, 71, 255, 169, 44, 246, 1, 165, 211, 204, 124, 169, 166, 176, 186, 217, 230, 249, 54, 217, 216, 58, 75, 47, 27, 11, 227, 220, 230, 158, 157, 78, 47, 236, 22, 246, 121, 4, 199, 194, 206, 150, 185, 8, 159, 64, 32, 169, 180, 152, 63, 110, 79, 85, 222, 23, 10, 112, 177, 171, 163, 178, 80, 198, 40, 152, 37, 158, 47, 50, 225 }, 0, "user10" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "Comment", "CreateDate", "Email", "Firstname", "Lastname", "Phone", "PickupDate", "PriorityId", "ServiceId", "StatusId", "UserId" },
                values: new object[,]
                {
                    { 1, "Erster Kommentar", new DateTime(2024, 1, 11, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(408), "max.mustermann@example.com", "Max", "Mustermann", "1234567890", new DateTime(2024, 1, 12, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(456), 1, 1, 1, null },
                    { 2, "Zweiter Kommentar", new DateTime(2024, 1, 11, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(463), "maria.musterfrau@example.com", "Maria", "Musterfrau", "0987654321", new DateTime(2024, 1, 13, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(465), 3, 2, 2, null },
                    { 3, "Dritter Kommentar", new DateTime(2024, 1, 11, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(467), "johannes.doe@example.com", "Johannes", "Doe", "1122334455", new DateTime(2024, 1, 14, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(469), 3, 3, 3, null },
                    { 4, "Vierter Kommentar", new DateTime(2024, 1, 11, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(471), "anna.beispiel@example.com", "Anna", "Beispiel", "2233445566", new DateTime(2024, 1, 15, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(472), 3, 4, 2, null },
                    { 5, "Fünfter Kommentar", new DateTime(2024, 1, 11, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(474), "lukas.muster@example.com", "Lukas", "Muster", "3344556677", new DateTime(2024, 1, 16, 11, 21, 22, 957, DateTimeKind.Local).AddTicks(475), 2, 5, 1, null }
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