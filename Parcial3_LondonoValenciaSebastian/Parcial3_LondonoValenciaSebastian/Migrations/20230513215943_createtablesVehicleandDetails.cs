using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial3_LondonoValenciaSebastian.Migrations
{
    /// <inheritdoc />
    public partial class createtablesVehicleandDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Services_Name",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberPlate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceService = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDetails_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_VehicleId",
                table: "VehicleDetails",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ServiceId",
                table: "Vehicles",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleDetails");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Name",
                table: "Services",
                column: "Name",
                unique: true);
        }
    }
}
