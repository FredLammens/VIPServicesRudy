using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataLayer.Migrations
{
    public partial class InitVIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Limousines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FirstHourPrice = table.Column<int>(nullable: false),
                    LastReservation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limousines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceCalculation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subtotal = table.Column<int>(nullable: false),
                    ChargedDiscounts = table.Column<decimal>(nullable: false),
                    TotalExclusiveVAT = table.Column<decimal>(nullable: false),
                    VATAmount = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCalculation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    VATNumber = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    CategorieName = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientNumber);
                    table.ForeignKey(
                        name: "FK_Clients_Categories_CategorieName",
                        column: x => x.CategorieName,
                        principalTable: "Categories",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aantal = table.Column<int>(nullable: false),
                    Korting = table.Column<float>(nullable: false),
                    CategoryName = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_Categories_CategoryName",
                        column: x => x.CategoryName,
                        principalTable: "Categories",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Arrangements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: true),
                    ArrangementType = table.Column<int>(nullable: false),
                    LimousineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrangements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arrangements_Limousines_LimousineId",
                        column: x => x.LimousineId,
                        principalTable: "Limousines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HourType = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<int>(nullable: false),
                    HourlyArrangementId = table.Column<int>(nullable: true),
                    PriceCalculationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hour_Arrangements_HourlyArrangementId",
                        column: x => x.HourlyArrangementId,
                        principalTable: "Arrangements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hour_PriceCalculation_PriceCalculationId",
                        column: x => x.PriceCalculationId,
                        principalTable: "PriceCalculation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDateStart = table.Column<DateTime>(nullable: false),
                    ReservationDateEnd = table.Column<DateTime>(nullable: false),
                    StartLocation = table.Column<int>(nullable: false),
                    ArrivalLocation = table.Column<int>(nullable: false),
                    LimousineId = table.Column<int>(nullable: true),
                    ArrangementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationDetails_Arrangements_ArrangementId",
                        column: x => x.ArrangementId,
                        principalTable: "Arrangements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationDetails_Limousines_LimousineId",
                        column: x => x.LimousineId,
                        principalTable: "Limousines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    Adres = table.Column<string>(nullable: true),
                    ClientNumber = table.Column<int>(nullable: true),
                    DetailsId = table.Column<int>(nullable: true),
                    PriceCalculationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientNumber",
                        column: x => x.ClientNumber,
                        principalTable: "Clients",
                        principalColumn: "ClientNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationDetails_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "ReservationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_PriceCalculation_PriceCalculationId",
                        column: x => x.PriceCalculationId,
                        principalTable: "PriceCalculation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arrangements_LimousineId",
                table: "Arrangements",
                column: "LimousineId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CategorieName",
                table: "Clients",
                column: "CategorieName");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_CategoryName",
                table: "Discount",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Hour_HourlyArrangementId",
                table: "Hour",
                column: "HourlyArrangementId");

            migrationBuilder.CreateIndex(
                name: "IX_Hour_PriceCalculationId",
                table: "Hour",
                column: "PriceCalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDetails_ArrangementId",
                table: "ReservationDetails",
                column: "ArrangementId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDetails_LimousineId",
                table: "ReservationDetails",
                column: "LimousineId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientNumber",
                table: "Reservations",
                column: "ClientNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DetailsId",
                table: "Reservations",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PriceCalculationId",
                table: "Reservations",
                column: "PriceCalculationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Hour");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ReservationDetails");

            migrationBuilder.DropTable(
                name: "PriceCalculation");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Arrangements");

            migrationBuilder.DropTable(
                name: "Limousines");
        }
    }
}
