using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Migrations
{
    /// <inheritdoc />
    public partial class FixedOneMissingRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PowerSupplies_Cases_CaseId",
                table: "PowerSupplies");

            migrationBuilder.DropIndex(
                name: "IX_PowerSupplies_CaseId",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "PowerSupplies");

            migrationBuilder.CreateTable(
                name: "CasePowerSupply",
                columns: table => new
                {
                    CompatibleCasesId = table.Column<int>(type: "int", nullable: false),
                    CompatiblePowerSuppliesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasePowerSupply", x => new { x.CompatibleCasesId, x.CompatiblePowerSuppliesId });
                    table.ForeignKey(
                        name: "FK_CasePowerSupply_Cases_CompatibleCasesId",
                        column: x => x.CompatibleCasesId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasePowerSupply_PowerSupplies_CompatiblePowerSuppliesId",
                        column: x => x.CompatiblePowerSuppliesId,
                        principalTable: "PowerSupplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasePowerSupply_CompatiblePowerSuppliesId",
                table: "CasePowerSupply",
                column: "CompatiblePowerSuppliesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasePowerSupply");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "PowerSupplies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplies_CaseId",
                table: "PowerSupplies",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PowerSupplies_Cases_CaseId",
                table: "PowerSupplies",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }
    }
}
