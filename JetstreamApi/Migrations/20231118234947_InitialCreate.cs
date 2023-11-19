﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JetstreamApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { 1, false, new byte[] { 155, 190, 94, 136, 172, 185, 13, 214, 156, 45, 9, 9, 239, 210, 180, 229, 181, 25, 118, 0, 226, 55, 251, 2, 150, 192, 50, 69, 236, 2, 30, 230, 37, 7, 146, 252, 35, 201, 138, 128, 191, 29, 139, 222, 119, 89, 111, 104, 35, 54, 133, 112, 102, 191, 145, 125, 7, 247, 182, 226, 133, 110, 125, 142 }, 0, new byte[] { 10, 100, 76, 30, 126, 207, 186, 29, 178, 113, 158, 59, 30, 204, 57, 165, 21, 159, 95, 72, 122, 77, 65, 201, 180, 3, 190, 16, 250, 219, 204, 137, 198, 230, 254, 170, 76, 78, 144, 63, 230, 144, 175, 7, 29, 221, 210, 152, 61, 180, 215, 13, 63, 142, 135, 131, 212, 211, 156, 143, 42, 83, 193, 119, 151, 248, 242, 111, 147, 31, 186, 122, 168, 246, 175, 202, 164, 50, 78, 30, 26, 227, 22, 148, 250, 181, 220, 42, 159, 249, 210, 63, 29, 2, 9, 149, 124, 226, 27, 167, 6, 71, 42, 152, 80, 79, 156, 200, 231, 105, 156, 234, 142, 60, 113, 195, 80, 102, 246, 226, 157, 23, 52, 253, 244, 107, 20, 207 }, "user1" },
                    { 2, false, new byte[] { 133, 107, 168, 203, 4, 64, 142, 170, 43, 146, 21, 129, 141, 164, 223, 249, 228, 149, 109, 18, 45, 47, 204, 248, 51, 255, 99, 127, 121, 146, 134, 247, 74, 128, 186, 77, 27, 17, 118, 188, 97, 147, 21, 48, 80, 167, 156, 176, 124, 122, 46, 92, 95, 122, 80, 125, 45, 141, 244, 225, 160, 16, 153, 37 }, 0, new byte[] { 222, 117, 65, 166, 219, 193, 158, 76, 125, 83, 248, 49, 235, 226, 248, 107, 227, 113, 187, 129, 72, 78, 238, 101, 190, 58, 158, 145, 233, 124, 166, 123, 216, 247, 182, 33, 228, 41, 88, 255, 8, 25, 122, 79, 219, 88, 52, 3, 244, 61, 255, 146, 114, 82, 240, 99, 32, 73, 244, 127, 223, 154, 8, 81, 111, 74, 144, 109, 183, 168, 195, 201, 216, 41, 191, 90, 6, 156, 166, 81, 74, 66, 23, 232, 191, 61, 40, 149, 56, 57, 91, 241, 66, 12, 234, 94, 74, 1, 6, 51, 66, 76, 133, 44, 13, 229, 149, 179, 247, 37, 75, 247, 14, 231, 78, 22, 43, 89, 128, 16, 163, 190, 141, 173, 117, 74, 230, 247 }, "user2" },
                    { 3, false, new byte[] { 96, 226, 132, 21, 57, 200, 247, 84, 18, 194, 153, 83, 22, 77, 132, 11, 33, 74, 27, 16, 72, 81, 243, 92, 45, 80, 90, 177, 154, 147, 164, 169, 72, 57, 196, 31, 195, 240, 182, 61, 39, 208, 61, 12, 215, 8, 181, 200, 215, 1, 163, 180, 78, 25, 179, 37, 103, 243, 10, 248, 44, 65, 142, 30 }, 0, new byte[] { 179, 75, 182, 236, 215, 139, 159, 20, 146, 121, 85, 28, 185, 217, 162, 65, 17, 45, 107, 58, 70, 180, 116, 147, 247, 159, 225, 192, 232, 169, 108, 251, 54, 147, 147, 118, 164, 144, 24, 25, 46, 57, 6, 5, 70, 100, 28, 91, 226, 193, 243, 236, 172, 50, 136, 126, 25, 58, 90, 145, 136, 5, 82, 105, 205, 231, 53, 182, 239, 63, 129, 172, 128, 222, 182, 151, 153, 41, 121, 86, 199, 172, 65, 199, 213, 221, 56, 215, 74, 133, 22, 182, 217, 230, 36, 145, 235, 51, 62, 234, 170, 180, 236, 157, 210, 161, 46, 114, 66, 1, 62, 57, 230, 158, 62, 200, 233, 117, 120, 90, 128, 81, 229, 73, 255, 55, 82, 208 }, "user3" },
                    { 4, false, new byte[] { 64, 184, 97, 218, 181, 137, 179, 135, 100, 72, 246, 244, 90, 58, 190, 65, 47, 60, 167, 175, 189, 99, 52, 185, 252, 31, 223, 223, 147, 227, 233, 58, 229, 24, 183, 90, 50, 143, 251, 174, 254, 92, 84, 113, 238, 199, 227, 50, 3, 99, 155, 107, 250, 161, 187, 15, 106, 156, 186, 131, 13, 240, 119, 22 }, 0, new byte[] { 85, 227, 92, 51, 250, 49, 121, 206, 83, 140, 189, 31, 26, 217, 147, 175, 214, 79, 22, 137, 64, 61, 22, 82, 197, 59, 42, 34, 95, 101, 165, 137, 220, 109, 68, 124, 15, 89, 35, 168, 134, 17, 250, 201, 148, 252, 159, 25, 191, 32, 118, 121, 236, 242, 52, 252, 200, 191, 77, 131, 101, 168, 62, 103, 39, 207, 249, 29, 119, 192, 131, 112, 71, 98, 96, 131, 139, 112, 27, 82, 177, 111, 72, 251, 150, 78, 2, 74, 42, 94, 225, 147, 224, 166, 182, 114, 171, 67, 132, 186, 91, 74, 55, 41, 213, 209, 246, 165, 211, 76, 50, 34, 4, 167, 168, 88, 182, 202, 188, 131, 44, 78, 107, 24, 252, 207, 227, 224 }, "user4" },
                    { 5, false, new byte[] { 53, 10, 183, 182, 188, 144, 158, 232, 152, 225, 127, 201, 151, 162, 238, 34, 51, 227, 103, 21, 111, 8, 128, 56, 79, 4, 128, 51, 64, 164, 186, 194, 60, 11, 44, 42, 215, 218, 46, 207, 134, 19, 213, 206, 49, 217, 40, 37, 134, 240, 204, 46, 61, 213, 37, 174, 162, 143, 121, 26, 176, 94, 80, 10 }, 0, new byte[] { 62, 88, 30, 234, 179, 45, 65, 121, 30, 231, 182, 232, 225, 48, 176, 49, 146, 25, 184, 144, 243, 247, 96, 108, 254, 133, 156, 7, 77, 215, 246, 2, 156, 176, 162, 136, 93, 195, 161, 247, 172, 68, 167, 67, 171, 52, 61, 227, 9, 81, 18, 155, 215, 253, 129, 112, 233, 3, 8, 17, 137, 8, 131, 0, 70, 178, 176, 2, 253, 188, 216, 125, 93, 147, 219, 62, 42, 243, 193, 244, 127, 17, 128, 81, 129, 7, 222, 25, 243, 181, 208, 2, 216, 5, 203, 198, 192, 233, 118, 231, 183, 118, 202, 226, 143, 125, 129, 16, 182, 244, 22, 92, 148, 49, 121, 112, 42, 254, 32, 230, 115, 167, 161, 216, 193, 9, 152, 20 }, "user5" },
                    { 6, false, new byte[] { 103, 92, 222, 96, 89, 53, 153, 156, 115, 177, 234, 119, 10, 58, 210, 157, 160, 81, 120, 32, 218, 100, 182, 169, 80, 36, 135, 57, 231, 131, 239, 254, 193, 253, 236, 248, 13, 73, 154, 5, 224, 110, 194, 18, 0, 91, 62, 151, 106, 15, 162, 183, 55, 170, 140, 70, 242, 193, 104, 136, 76, 105, 28, 25 }, 0, new byte[] { 94, 196, 80, 129, 210, 136, 178, 232, 21, 95, 177, 213, 10, 56, 149, 188, 255, 16, 153, 185, 77, 143, 169, 113, 91, 87, 180, 82, 56, 195, 28, 12, 155, 89, 204, 56, 72, 171, 16, 13, 182, 5, 219, 203, 91, 121, 237, 55, 164, 111, 240, 162, 153, 79, 188, 176, 124, 246, 57, 168, 237, 233, 133, 162, 253, 23, 40, 222, 121, 13, 200, 255, 214, 16, 67, 12, 108, 177, 44, 252, 191, 94, 149, 158, 126, 75, 147, 82, 152, 45, 124, 230, 43, 56, 61, 231, 193, 94, 153, 126, 22, 247, 141, 5, 141, 159, 147, 236, 116, 229, 226, 72, 92, 13, 144, 144, 246, 53, 134, 138, 121, 116, 71, 112, 197, 183, 13, 164 }, "user6" },
                    { 7, false, new byte[] { 225, 182, 5, 212, 180, 50, 100, 96, 144, 140, 112, 205, 62, 59, 32, 202, 177, 148, 80, 6, 149, 41, 240, 84, 172, 144, 208, 15, 144, 100, 131, 230, 33, 46, 197, 250, 217, 199, 80, 167, 1, 193, 203, 64, 22, 85, 123, 83, 169, 117, 199, 48, 26, 20, 2, 184, 220, 8, 201, 114, 139, 1, 152, 123 }, 0, new byte[] { 222, 233, 165, 80, 225, 120, 118, 182, 221, 39, 204, 50, 96, 143, 74, 56, 26, 55, 60, 102, 82, 27, 98, 124, 33, 254, 207, 28, 55, 112, 47, 217, 207, 203, 207, 48, 252, 213, 128, 214, 83, 18, 52, 43, 94, 1, 189, 200, 123, 66, 215, 177, 18, 119, 181, 3, 234, 124, 20, 47, 206, 145, 89, 239, 32, 131, 168, 79, 56, 42, 153, 251, 101, 204, 171, 69, 162, 139, 73, 235, 159, 196, 198, 56, 172, 183, 175, 124, 222, 55, 184, 23, 246, 180, 186, 31, 246, 180, 46, 227, 66, 191, 201, 202, 40, 253, 71, 95, 71, 178, 191, 98, 65, 2, 107, 132, 130, 169, 203, 101, 43, 8, 58, 155, 225, 153, 50, 75 }, "user7" },
                    { 8, false, new byte[] { 195, 34, 135, 48, 147, 138, 81, 143, 218, 255, 171, 133, 249, 69, 218, 192, 50, 8, 183, 6, 64, 111, 223, 53, 70, 6, 239, 21, 251, 12, 175, 215, 230, 35, 177, 99, 190, 74, 146, 203, 159, 135, 125, 56, 254, 235, 96, 177, 156, 218, 149, 6, 147, 15, 141, 43, 20, 10, 38, 16, 142, 22, 152, 143 }, 0, new byte[] { 235, 23, 156, 12, 228, 239, 161, 210, 48, 131, 55, 33, 244, 71, 239, 234, 33, 225, 42, 6, 73, 109, 127, 156, 128, 207, 2, 162, 232, 199, 128, 173, 52, 45, 117, 117, 163, 27, 16, 188, 232, 21, 19, 118, 133, 194, 38, 5, 254, 192, 2, 249, 89, 238, 194, 195, 144, 70, 2, 90, 248, 68, 67, 102, 250, 67, 106, 47, 58, 9, 194, 237, 33, 76, 127, 202, 72, 108, 61, 104, 119, 63, 38, 129, 118, 129, 30, 164, 20, 46, 124, 198, 154, 131, 193, 36, 150, 44, 155, 113, 10, 66, 150, 162, 118, 34, 122, 200, 117, 130, 84, 141, 250, 157, 229, 37, 53, 37, 153, 187, 128, 5, 184, 49, 123, 160, 71, 145 }, "user8" },
                    { 9, false, new byte[] { 96, 173, 78, 237, 63, 247, 72, 53, 89, 35, 125, 192, 4, 39, 66, 136, 105, 176, 13, 184, 204, 13, 39, 197, 216, 229, 194, 119, 72, 135, 220, 160, 8, 59, 123, 195, 217, 110, 56, 8, 108, 160, 199, 131, 225, 116, 220, 135, 196, 20, 147, 28, 25, 111, 183, 176, 20, 11, 155, 145, 141, 68, 159, 176 }, 0, new byte[] { 202, 180, 10, 198, 47, 250, 252, 36, 80, 74, 33, 155, 31, 6, 35, 72, 147, 162, 83, 134, 168, 237, 36, 118, 113, 140, 186, 16, 163, 53, 111, 134, 7, 161, 129, 94, 1, 111, 104, 3, 140, 154, 135, 130, 59, 96, 109, 143, 86, 230, 160, 75, 31, 127, 223, 252, 171, 145, 9, 114, 179, 85, 0, 26, 8, 98, 51, 16, 33, 204, 247, 131, 121, 247, 20, 15, 159, 38, 204, 163, 100, 168, 150, 44, 47, 71, 228, 236, 139, 177, 23, 88, 63, 144, 1, 147, 168, 59, 88, 231, 176, 56, 83, 193, 200, 32, 74, 96, 22, 212, 78, 255, 45, 250, 94, 60, 176, 235, 49, 96, 108, 163, 115, 191, 117, 207, 119, 39 }, "user9" },
                    { 10, false, new byte[] { 231, 160, 63, 235, 228, 53, 15, 75, 122, 14, 253, 221, 126, 254, 55, 244, 254, 74, 50, 99, 121, 176, 10, 93, 200, 84, 168, 194, 158, 194, 71, 179, 97, 16, 94, 120, 241, 5, 219, 134, 34, 90, 155, 150, 17, 185, 71, 31, 231, 63, 67, 10, 82, 15, 247, 246, 38, 228, 151, 67, 167, 102, 4, 208 }, 0, new byte[] { 126, 36, 198, 91, 215, 209, 113, 210, 89, 135, 233, 170, 255, 190, 232, 222, 109, 77, 144, 164, 28, 202, 59, 164, 133, 56, 34, 237, 91, 185, 81, 208, 224, 41, 214, 39, 195, 170, 11, 124, 133, 32, 60, 188, 64, 20, 191, 205, 21, 93, 150, 154, 54, 193, 208, 47, 67, 30, 176, 167, 94, 55, 130, 227, 206, 50, 111, 216, 4, 146, 27, 94, 27, 144, 199, 47, 89, 191, 18, 200, 132, 90, 190, 199, 129, 9, 237, 14, 242, 71, 27, 160, 255, 157, 46, 29, 148, 249, 110, 205, 8, 129, 133, 70, 149, 149, 78, 48, 170, 215, 141, 98, 12, 123, 13, 214, 170, 250, 45, 253, 11, 29, 44, 158, 31, 39, 243, 21 }, "user10" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "Comment", "CreateDate", "Email", "Firstname", "Lastname", "Phone", "PickupDate", "PriorityId", "ServiceId", "StatusId", "UserId" },
                values: new object[,]
                {
                    { 1, "Erster Kommentar", new DateTime(2023, 11, 19, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6506), "max.mustermann@example.com", "Max", "Mustermann", "1234567890", new DateTime(2023, 11, 20, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6550), 1, 1, 1, null },
                    { 2, "Zweiter Kommentar", new DateTime(2023, 11, 19, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6556), "maria.musterfrau@example.com", "Maria", "Musterfrau", "0987654321", new DateTime(2023, 11, 21, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6557), 2, 2, 2, null },
                    { 3, "Dritter Kommentar", new DateTime(2023, 11, 19, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6560), "johannes.doe@example.com", "Johannes", "Doe", "1122334455", new DateTime(2023, 11, 22, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6561), 1, 3, 3, null },
                    { 4, "Vierter Kommentar", new DateTime(2023, 11, 19, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6563), "anna.beispiel@example.com", "Anna", "Beispiel", "2233445566", new DateTime(2023, 11, 23, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6564), 3, 4, 2, null },
                    { 5, "Fünfter Kommentar", new DateTime(2023, 11, 19, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6587), "lukas.muster@example.com", "Lukas", "Muster", "3344556677", new DateTime(2023, 11, 24, 0, 49, 47, 85, DateTimeKind.Local).AddTicks(6588), 2, 5, 1, null }
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