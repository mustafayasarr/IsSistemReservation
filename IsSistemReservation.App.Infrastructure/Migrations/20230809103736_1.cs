using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsSistemReservation.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    TelNo = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedAtUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    EnvironmentName = table.Column<string>(type: "text", nullable: false),
                    CreatedAtUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    TableNo = table.Column<string>(type: "text", nullable: false),
                    ChairsCount = table.Column<int>(type: "integer", nullable: false),
                    BabyHighchairsCount = table.Column<int>(type: "integer", nullable: false),
                    TableCategory = table.Column<Guid>(type: "uuid", nullable: false),
                    TableCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAtUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantTable_TableCategory_TableCategoryId",
                        column: x => x.TableCategoryId,
                        principalTable: "TableCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    RestaurantTableId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PersonCount = table.Column<int>(type: "integer", nullable: false),
                    BabyCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedAtUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_RestaurantTable_RestaurantTableId",
                        column: x => x.RestaurantTableId,
                        principalTable: "RestaurantTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CustomerId",
                table: "Booking",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RestaurantTableId",
                table: "Booking",
                column: "RestaurantTableId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTable_TableCategoryId",
                table: "RestaurantTable",
                column: "TableCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "RestaurantTable");

            migrationBuilder.DropTable(
                name: "TableCategory");
        }
    }
}
