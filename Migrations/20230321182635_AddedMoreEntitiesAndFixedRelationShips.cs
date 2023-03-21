using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreEntitiesAndFixedRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_GPUs_GPUId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Port_MotherBoards_MotherboardId",
                table: "Port");

            migrationBuilder.DropForeignKey(
                name: "FK_Port_PowerSupplies_PowerSupplyId",
                table: "Port");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerSupplies_GPUs_GPUId",
                table: "PowerSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Sockets_CPUCoolers_CPUCoolerId",
                table: "Sockets");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageSlots_Cases_CaseId",
                table: "StorageSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageSlots_MotherBoards_MotherboardId",
                table: "StorageSlots");

            migrationBuilder.DropTable(
                name: "CPURAM");

            migrationBuilder.DropTable(
                name: "GPUMotherboard");

            migrationBuilder.DropIndex(
                name: "IX_StorageSlots_CaseId",
                table: "StorageSlots");

            migrationBuilder.DropIndex(
                name: "IX_StorageSlots_MotherboardId",
                table: "StorageSlots");

            migrationBuilder.DropIndex(
                name: "IX_Sockets_CPUCoolerId",
                table: "Sockets");

            migrationBuilder.DropIndex(
                name: "IX_PowerSupplies_GPUId",
                table: "PowerSupplies");

            migrationBuilder.DropIndex(
                name: "IX_Port_MotherboardId",
                table: "Port");

            migrationBuilder.DropIndex(
                name: "IX_Port_PowerSupplyId",
                table: "Port");

            migrationBuilder.DropIndex(
                name: "IX_Cases_GPUId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "StorageSlots");

            migrationBuilder.DropColumn(
                name: "MotherboardId",
                table: "StorageSlots");

            migrationBuilder.DropColumn(
                name: "CPUCoolerId",
                table: "Sockets");

            migrationBuilder.DropColumn(
                name: "GPUId",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "MotherboardId",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "PowerSupplyId",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "Chipset",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "Socket",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "Socket",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "GPUId",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "Manufactorer",
                table: "PowerSupplies",
                newName: "Manufacturer");

            migrationBuilder.AddColumn<int>(
                name: "ChipsetId",
                table: "MotherBoards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SocketId",
                table: "MotherBoards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RAMId",
                table: "CPUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocketId",
                table: "CPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CaseGPU",
                columns: table => new
                {
                    CompatibleCasesId = table.Column<int>(type: "int", nullable: false),
                    CompatibleGpusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseGPU", x => new { x.CompatibleCasesId, x.CompatibleGpusId });
                    table.ForeignKey(
                        name: "FK_CaseGPU_Cases_CompatibleCasesId",
                        column: x => x.CompatibleCasesId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseGPU_GPUs_CompatibleGpusId",
                        column: x => x.CompatibleGpusId,
                        principalTable: "GPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chipsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chipsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPUCoolerSocket",
                columns: table => new
                {
                    CPUCoolersId = table.Column<int>(type: "int", nullable: false),
                    SocketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUCoolerSocket", x => new { x.CPUCoolersId, x.SocketsId });
                    table.ForeignKey(
                        name: "FK_CPUCoolerSocket_CPUCoolers_CPUCoolersId",
                        column: x => x.CPUCoolersId,
                        principalTable: "CPUCoolers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUCoolerSocket_Sockets_SocketsId",
                        column: x => x.SocketsId,
                        principalTable: "Sockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalConnectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalConnectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotherboardPort",
                columns: table => new
                {
                    BackPanelPortsId = table.Column<int>(type: "int", nullable: false),
                    MotherboardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherboardPort", x => new { x.BackPanelPortsId, x.MotherboardsId });
                    table.ForeignKey(
                        name: "FK_MotherboardPort_MotherBoards_MotherboardsId",
                        column: x => x.MotherboardsId,
                        principalTable: "MotherBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotherboardPort_Port_BackPanelPortsId",
                        column: x => x.BackPanelPortsId,
                        principalTable: "Port",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotherboardStorageSlot",
                columns: table => new
                {
                    MotherboardsId = table.Column<int>(type: "int", nullable: false),
                    StorageSlotsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherboardStorageSlot", x => new { x.MotherboardsId, x.StorageSlotsId });
                    table.ForeignKey(
                        name: "FK_MotherboardStorageSlot_MotherBoards_MotherboardsId",
                        column: x => x.MotherboardsId,
                        principalTable: "MotherBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotherboardStorageSlot_StorageSlots_StorageSlotsId",
                        column: x => x.StorageSlotsId,
                        principalTable: "StorageSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadSpeed = table.Column<int>(type: "int", nullable: false),
                    WriteSpeed = table.Column<int>(type: "int", nullable: false),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalConnectorMotherboard",
                columns: table => new
                {
                    InternalConnectorsId = table.Column<int>(type: "int", nullable: false),
                    MotherboardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalConnectorMotherboard", x => new { x.InternalConnectorsId, x.MotherboardsId });
                    table.ForeignKey(
                        name: "FK_InternalConnectorMotherboard_InternalConnectors_InternalConnectorsId",
                        column: x => x.InternalConnectorsId,
                        principalTable: "InternalConnectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalConnectorMotherboard_MotherBoards_MotherboardsId",
                        column: x => x.MotherboardsId,
                        principalTable: "MotherBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalConnectorPowerSupply",
                columns: table => new
                {
                    ConnectorsId = table.Column<int>(type: "int", nullable: false),
                    PowerSuppliesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalConnectorPowerSupply", x => new { x.ConnectorsId, x.PowerSuppliesId });
                    table.ForeignKey(
                        name: "FK_InternalConnectorPowerSupply_InternalConnectors_ConnectorsId",
                        column: x => x.ConnectorsId,
                        principalTable: "InternalConnectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalConnectorPowerSupply_PowerSupplies_PowerSuppliesId",
                        column: x => x.PowerSuppliesId,
                        principalTable: "PowerSupplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_CaseStorage_Storage_CompatibleStoragesId",
                        column: x => x.CompatibleStoragesId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotherBoards_ChipsetId",
                table: "MotherBoards",
                column: "ChipsetId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherBoards_SocketId",
                table: "MotherBoards",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_RAMId",
                table: "CPUs",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_SocketId",
                table: "CPUs",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseGPU_CompatibleGpusId",
                table: "CaseGPU",
                column: "CompatibleGpusId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseStorage_CompatibleStoragesId",
                table: "CaseStorage",
                column: "CompatibleStoragesId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUCoolerSocket_SocketsId",
                table: "CPUCoolerSocket",
                column: "SocketsId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalConnectorMotherboard_MotherboardsId",
                table: "InternalConnectorMotherboard",
                column: "MotherboardsId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalConnectorPowerSupply_PowerSuppliesId",
                table: "InternalConnectorPowerSupply",
                column: "PowerSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardPort_MotherboardsId",
                table: "MotherboardPort",
                column: "MotherboardsId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardStorageSlot_StorageSlotsId",
                table: "MotherboardStorageSlot",
                column: "StorageSlotsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Memories_RAMId",
                table: "CPUs",
                column: "RAMId",
                principalTable: "Memories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Sockets_SocketId",
                table: "CPUs",
                column: "SocketId",
                principalTable: "Sockets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherBoards_Chipsets_ChipsetId",
                table: "MotherBoards",
                column: "ChipsetId",
                principalTable: "Chipsets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherBoards_Sockets_SocketId",
                table: "MotherBoards",
                column: "SocketId",
                principalTable: "Sockets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Memories_RAMId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Sockets_SocketId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherBoards_Chipsets_ChipsetId",
                table: "MotherBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherBoards_Sockets_SocketId",
                table: "MotherBoards");

            migrationBuilder.DropTable(
                name: "CaseGPU");

            migrationBuilder.DropTable(
                name: "CaseStorage");

            migrationBuilder.DropTable(
                name: "Chipsets");

            migrationBuilder.DropTable(
                name: "CPUCoolerSocket");

            migrationBuilder.DropTable(
                name: "InternalConnectorMotherboard");

            migrationBuilder.DropTable(
                name: "InternalConnectorPowerSupply");

            migrationBuilder.DropTable(
                name: "MotherboardPort");

            migrationBuilder.DropTable(
                name: "MotherboardStorageSlot");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "InternalConnectors");

            migrationBuilder.DropIndex(
                name: "IX_MotherBoards_ChipsetId",
                table: "MotherBoards");

            migrationBuilder.DropIndex(
                name: "IX_MotherBoards_SocketId",
                table: "MotherBoards");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_RAMId",
                table: "CPUs");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_SocketId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "ChipsetId",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "SocketId",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "RAMId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "SocketId",
                table: "CPUs");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "PowerSupplies",
                newName: "Manufactorer");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "StorageSlots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherboardId",
                table: "StorageSlots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CPUCoolerId",
                table: "Sockets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GPUId",
                table: "PowerSupplies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherboardId",
                table: "Port",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PowerSupplyId",
                table: "Port",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Chipset",
                table: "MotherBoards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Socket",
                table: "MotherBoards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Socket",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GPUId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CPURAM",
                columns: table => new
                {
                    CompatibleCpusId = table.Column<int>(type: "int", nullable: false),
                    CompatibleRamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPURAM", x => new { x.CompatibleCpusId, x.CompatibleRamId });
                    table.ForeignKey(
                        name: "FK_CPURAM_CPUs_CompatibleCpusId",
                        column: x => x.CompatibleCpusId,
                        principalTable: "CPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPURAM_Memories_CompatibleRamId",
                        column: x => x.CompatibleRamId,
                        principalTable: "Memories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPUMotherboard",
                columns: table => new
                {
                    CompatibleGpusId = table.Column<int>(type: "int", nullable: false),
                    CompatibleMotherboardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUMotherboard", x => new { x.CompatibleGpusId, x.CompatibleMotherboardsId });
                    table.ForeignKey(
                        name: "FK_GPUMotherboard_GPUs_CompatibleGpusId",
                        column: x => x.CompatibleGpusId,
                        principalTable: "GPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPUMotherboard_MotherBoards_CompatibleMotherboardsId",
                        column: x => x.CompatibleMotherboardsId,
                        principalTable: "MotherBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StorageSlots_CaseId",
                table: "StorageSlots",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSlots_MotherboardId",
                table: "StorageSlots",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Sockets_CPUCoolerId",
                table: "Sockets",
                column: "CPUCoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplies_GPUId",
                table: "PowerSupplies",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Port_MotherboardId",
                table: "Port",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Port_PowerSupplyId",
                table: "Port",
                column: "PowerSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_GPUId",
                table: "Cases",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_CPURAM_CompatibleRamId",
                table: "CPURAM",
                column: "CompatibleRamId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUMotherboard_CompatibleMotherboardsId",
                table: "GPUMotherboard",
                column: "CompatibleMotherboardsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_GPUs_GPUId",
                table: "Cases",
                column: "GPUId",
                principalTable: "GPUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Port_MotherBoards_MotherboardId",
                table: "Port",
                column: "MotherboardId",
                principalTable: "MotherBoards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Port_PowerSupplies_PowerSupplyId",
                table: "Port",
                column: "PowerSupplyId",
                principalTable: "PowerSupplies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PowerSupplies_GPUs_GPUId",
                table: "PowerSupplies",
                column: "GPUId",
                principalTable: "GPUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sockets_CPUCoolers_CPUCoolerId",
                table: "Sockets",
                column: "CPUCoolerId",
                principalTable: "CPUCoolers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSlots_Cases_CaseId",
                table: "StorageSlots",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSlots_MotherBoards_MotherboardId",
                table: "StorageSlots",
                column: "MotherboardId",
                principalTable: "MotherBoards",
                principalColumn: "Id");
        }
    }
}
