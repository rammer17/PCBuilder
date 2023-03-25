using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCaseRelationshipWithStorageAndChangedOneColumnInCaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseStorage");

            migrationBuilder.RenameColumn(
                name: "MotherboardFormFactor",
                table: "Cases",
                newName: "FormFactor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FormFactor",
                table: "Cases",
                newName: "MotherboardFormFactor");

            migrationBuilder.CreateTable(
                name: "CaseStorage",
                columns: table => new
                {
                    CompatibleCasesId = table.Column<int>(type: "int", nullable: false),
                    CompatibleStoragesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStorage", x => new { x.CompatibleCasesId, x.CompatibleStoragesId });
                    table.ForeignKey(
                        name: "FK_CaseStorage_Cases_CompatibleCasesId",
                        column: x => x.CompatibleCasesId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseStorage_Storages_CompatibleStoragesId",
                        column: x => x.CompatibleStoragesId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseStorage_CompatibleStoragesId",
                table: "CaseStorage",
                column: "CompatibleStoragesId");
        }
    }
}
