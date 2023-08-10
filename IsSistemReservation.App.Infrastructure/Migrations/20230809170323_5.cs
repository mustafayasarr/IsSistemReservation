using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsSistemReservation.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedAtUTC",
                table: "TableCategory",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                table: "TableCategory",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUTC",
                table: "Table",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                table: "Table",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUTC",
                table: "Reservation",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                table: "Reservation",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUTC",
                table: "Customer",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                table: "Customer",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "TableCategory",
                newName: "ModifiedAtUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "TableCategory",
                newName: "CreatedAtUTC");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Table",
                newName: "ModifiedAtUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Table",
                newName: "CreatedAtUTC");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Reservation",
                newName: "ModifiedAtUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Reservation",
                newName: "CreatedAtUTC");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Customer",
                newName: "ModifiedAtUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Customer",
                newName: "CreatedAtUTC");
        }
    }
}
