﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicevært.Web.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lejemaal",
                columns: table => new
                {
                    LejemålId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBookable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejemaal", x => x.LejemålId);
                });

            migrationBuilder.CreateTable(
                name: "Pedel",
                columns: table => new
                {
                    PedelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedelNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedel", x => x.PedelId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LejemålId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Lejemaal_LejemålId",
                        column: x => x.LejemålId,
                        principalTable: "Lejemaal",
                        principalColumn: "LejemålId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lejer",
                columns: table => new
                {
                    LejerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LejemaalId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejer", x => x.LejerId);
                    table.ForeignKey(
                        name: "FK_Lejer_Lejemaal_LejemaalId",
                        column: x => x.LejemaalId,
                        principalTable: "Lejemaal",
                        principalColumn: "LejemålId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rekvisition",
                columns: table => new
                {
                    RekvisitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RekvisitionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kommentar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LejerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekvisition", x => x.RekvisitionId);
                    table.ForeignKey(
                        name: "FK_Rekvisition_Lejer_LejerId",
                        column: x => x.LejerId,
                        principalTable: "Lejer",
                        principalColumn: "LejerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TidsRegistrerings",
                columns: table => new
                {
                    TidsRegistreringsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PedelId = table.Column<int>(type: "int", nullable: false),
                    RekvisitionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TidsRegistrerings", x => x.TidsRegistreringsId);
                    table.ForeignKey(
                        name: "FK_TidsRegistrerings_Pedel_PedelId",
                        column: x => x.PedelId,
                        principalTable: "Pedel",
                        principalColumn: "PedelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TidsRegistrerings_Rekvisition_RekvisitionsId",
                        column: x => x.RekvisitionsId,
                        principalTable: "Rekvisition",
                        principalColumn: "RekvisitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_LejemålId",
                table: "Bookings",
                column: "LejemålId");

            migrationBuilder.CreateIndex(
                name: "IX_Lejer_LejemaalId",
                table: "Lejer",
                column: "LejemaalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekvisition_LejerId",
                table: "Rekvisition",
                column: "LejerId");

            migrationBuilder.CreateIndex(
                name: "IX_TidsRegistrerings_PedelId",
                table: "TidsRegistrerings",
                column: "PedelId");

            migrationBuilder.CreateIndex(
                name: "IX_TidsRegistrerings_RekvisitionsId",
                table: "TidsRegistrerings",
                column: "RekvisitionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "TidsRegistrerings");

            migrationBuilder.DropTable(
                name: "Pedel");

            migrationBuilder.DropTable(
                name: "Rekvisition");

            migrationBuilder.DropTable(
                name: "Lejer");

            migrationBuilder.DropTable(
                name: "Lejemaal");
        }
    }
}
