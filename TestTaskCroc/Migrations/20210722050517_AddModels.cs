using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TestTaskCroc.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "cars",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    GovNumber = table.Column<string>(type: "text", nullable: true),
                    TypeOfGearShiftBox = table.Column<int>(type: "integer", nullable: false),
                    EngineVolume = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    EngineForce = table.Column<float>(type: "real", nullable: false),
                    DepreciationCoef = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    InsuranceCoef = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    MaintenanceCoef = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    CarCost = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    DateOfPurchase = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PassportNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trips",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorkerId = table.Column<int>(type: "integer", nullable: true),
                    CarId = table.Column<int>(type: "integer", nullable: true),
                    Range = table.Column<float>(type: "real", nullable: false),
                    CostOfSpentFuel = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.ID);
                    table.ForeignKey(
                        name: "FK_trips_cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "public",
                        principalTable: "cars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trips_workers_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "public",
                        principalTable: "workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trips_CarId",
                schema: "public",
                table: "trips",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_WorkerId",
                schema: "public",
                table: "trips",
                column: "WorkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trips",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cars",
                schema: "public");

            migrationBuilder.DropTable(
                name: "workers",
                schema: "public");
        }
    }
}
