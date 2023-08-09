using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsSistemReservation.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customer_CustomerId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_RestaurantTable_TableId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_TableId",
                table: "Reservation",
                newName: "IX_Reservation_TableId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_CustomerId",
                table: "Reservation",
                newName: "IX_Reservation_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customer_CustomerId",
                table: "Reservation",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_RestaurantTable_TableId",
                table: "Reservation",
                column: "TableId",
                principalTable: "RestaurantTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customer_CustomerId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_RestaurantTable_TableId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_TableId",
                table: "Booking",
                newName: "IX_Booking_TableId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_CustomerId",
                table: "Booking",
                newName: "IX_Booking_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customer_CustomerId",
                table: "Booking",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_RestaurantTable_TableId",
                table: "Booking",
                column: "TableId",
                principalTable: "RestaurantTable",
                principalColumn: "Id");
        }
    }
}
