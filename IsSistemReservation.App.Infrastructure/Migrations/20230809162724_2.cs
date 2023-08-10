using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsSistemReservation.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_RestaurantTable_RestaurantTableId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_RestaurantTableId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "TableNo",
                table: "RestaurantTable");

            migrationBuilder.DropColumn(
                name: "BabyCount",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "ChairsCount",
                table: "RestaurantTable",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "BabyHighchairsCount",
                table: "RestaurantTable",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Booking",
                newName: "ReservationDate");

            migrationBuilder.RenameColumn(
                name: "PersonCount",
                table: "Booking",
                newName: "NumberOfGuests");

            migrationBuilder.AddColumn<int>(
                name: "BabyCapacity",
                table: "RestaurantTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TableId",
                table: "Booking",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TableId",
                table: "Booking",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_RestaurantTable_TableId",
                table: "Booking",
                column: "TableId",
                principalTable: "RestaurantTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_RestaurantTable_TableId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_TableId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "BabyCapacity",
                table: "RestaurantTable");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "RestaurantTable",
                newName: "ChairsCount");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "RestaurantTable",
                newName: "BabyHighchairsCount");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Booking",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "NumberOfGuests",
                table: "Booking",
                newName: "PersonCount");

            migrationBuilder.AddColumn<string>(
                name: "TableNo",
                table: "RestaurantTable",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BabyCount",
                table: "Booking",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Booking",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RestaurantTableId",
                table: "Booking",
                column: "RestaurantTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_RestaurantTable_RestaurantTableId",
                table: "Booking",
                column: "RestaurantTableId",
                principalTable: "RestaurantTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
