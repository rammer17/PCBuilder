using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumnNameInCaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MagGpuWidth",
                table: "Cases",
                newName: "MaxGpuWidth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxGpuWidth",
                table: "Cases",
                newName: "MagGpuWidth");
        }
    }
}
