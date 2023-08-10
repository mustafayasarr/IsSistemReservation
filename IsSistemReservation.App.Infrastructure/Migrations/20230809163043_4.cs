using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsSistemReservation.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_RestaurantTable_TableId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTable_TableCategory_TableCategoryId",
                table: "RestaurantTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantTable",
                table: "RestaurantTable");

            migrationBuilder.RenameTable(
                name: "RestaurantTable",
                newName: "Table");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantTable_TableCategoryId",
                table: "Table",
                newName: "IX_Table_TableCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Table_TableId",
                table: "Reservation",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_TableCategory_TableCategoryId",
                table: "Table",
                column: "TableCategoryId",
                principalTable: "TableCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Table_TableId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_TableCategory_TableCategoryId",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.RenameTable(
                name: "Table",
                newName: "RestaurantTable");

            migrationBuilder.RenameIndex(
                name: "IX_Table_TableCategoryId",
                table: "RestaurantTable",
                newName: "IX_RestaurantTable_TableCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantTable",
                table: "RestaurantTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_RestaurantTable_TableId",
                table: "Reservation",
                column: "TableId",
                principalTable: "RestaurantTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTable_TableCategory_TableCategoryId",
                table: "RestaurantTable",
                column: "TableCategoryId",
                principalTable: "TableCategory",
                principalColumn: "Id");
        }
    }
}
