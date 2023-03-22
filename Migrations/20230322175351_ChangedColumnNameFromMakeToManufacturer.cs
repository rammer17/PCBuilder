using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Migrations
{
    /// <inheritdoc />
    public partial class ChangedColumnNameFromMakeToManufacturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Make",
                table: "Storages",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Make",
                table: "MotherBoards",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Make",
                table: "Memories",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Make",
                table: "GPUs",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Make",
                table: "CPUs",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Make",
                table: "CPUCoolers",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Manufactorer",
                table: "Cases",
                newName: "Manufacturer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Storages",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "MotherBoards",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Memories",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "GPUs",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "CPUs",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "CPUCoolers",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Cases",
                newName: "Manufactorer");
        }
    }
}
