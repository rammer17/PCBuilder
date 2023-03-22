using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddedPortsAndStorageTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseStorage_Storage_CompatibleStoragesId",
                table: "CaseStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherboardPort_Port_BackPanelPortsId",
                table: "MotherboardPort");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storage",
                table: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Port",
                table: "Port");

            migrationBuilder.RenameTable(
                name: "Storage",
                newName: "Storages");

            migrationBuilder.RenameTable(
                name: "Port",
                newName: "Ports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storages",
                table: "Storages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ports",
                table: "Ports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseStorage_Storages_CompatibleStoragesId",
                table: "CaseStorage",
                column: "CompatibleStoragesId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherboardPort_Ports_BackPanelPortsId",
                table: "MotherboardPort",
                column: "BackPanelPortsId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseStorage_Storages_CompatibleStoragesId",
                table: "CaseStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherboardPort_Ports_BackPanelPortsId",
                table: "MotherboardPort");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storages",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ports",
                table: "Ports");

            migrationBuilder.RenameTable(
                name: "Storages",
                newName: "Storage");

            migrationBuilder.RenameTable(
                name: "Ports",
                newName: "Port");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storage",
                table: "Storage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Port",
                table: "Port",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseStorage_Storage_CompatibleStoragesId",
                table: "CaseStorage",
                column: "CompatibleStoragesId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherboardPort_Port_BackPanelPortsId",
                table: "MotherboardPort",
                column: "BackPanelPortsId",
                principalTable: "Port",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
