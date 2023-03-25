using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddedHeightAndWidthDimensiondForGpuAndCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "GPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "GPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MagGpuWidth",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxGpuHeight",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "MagGpuWidth",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "MaxGpuHeight",
                table: "Cases");
        }
    }
}
