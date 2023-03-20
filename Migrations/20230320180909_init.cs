using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPUCoolers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TDP = table.Column<int>(type: "int", nullable: false),
                    MaxRPM = table.Column<int>(type: "int", nullable: false),
                    NoiseLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUCoolers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Threads = table.Column<int>(type: "int", nullable: false),
                    BaseClock = table.Column<double>(type: "float", nullable: false),
                    MaxBoostClock = table.Column<double>(type: "float", nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseClock = table.Column<double>(type: "float", nullable: false),
                    MaxBoostClock = table.Column<double>(type: "float", nullable: false),
                    MemorySize = table.Column<int>(type: "int", nullable: false),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemoryBus = table.Column<int>(type: "int", nullable: false),
                    TDP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timing = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotherBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemorySlots = table.Column<int>(type: "int", nullable: false),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxMemorySpeed = table.Column<int>(type: "int", nullable: false),
                    Wifi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sockets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sockets_CPUCoolers_CPUCoolerId",
                        column: x => x.CPUCoolerId,
                        principalTable: "CPUCoolers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CPUCPUCooler",
                columns: table => new
                {
                    CompatibleCpuCoolersId = table.Column<int>(type: "int", nullable: false),
                    CompatibleCpusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUCPUCooler", x => new { x.CompatibleCpuCoolersId, x.CompatibleCpusId });
                    table.ForeignKey(
                        name: "FK_CPUCPUCooler_CPUCoolers_CompatibleCpuCoolersId",
                        column: x => x.CompatibleCpuCoolersId,
                        principalTable: "CPUCoolers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUCPUCooler_CPUs_CompatibleCpusId",
                        column: x => x.CompatibleCpusId,
                        principalTable: "CPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufactorer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardFormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_GPUs_GPUId",
                        column: x => x.GPUId,
                        principalTable: "GPUs",
                        principalColumn: "Id");
                });

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
                name: "CPUMotherboard",
                columns: table => new
                {
                    CompatibleCpusId = table.Column<int>(type: "int", nullable: false),
                    CompatibleMotherboardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUMotherboard", x => new { x.CompatibleCpusId, x.CompatibleMotherboardsId });
                    table.ForeignKey(
                        name: "FK_CPUMotherboard_CPUs_CompatibleCpusId",
                        column: x => x.CompatibleCpusId,
                        principalTable: "CPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUMotherboard_MotherBoards_CompatibleMotherboardsId",
                        column: x => x.CompatibleMotherboardsId,
                        principalTable: "MotherBoards",
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

            migrationBuilder.CreateTable(
                name: "MotherboardRAM",
                columns: table => new
                {
                    CompatibleMotherboardsId = table.Column<int>(type: "int", nullable: false),
                    CompatibleRamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherboardRAM", x => new { x.CompatibleMotherboardsId, x.CompatibleRamId });
                    table.ForeignKey(
                        name: "FK_MotherboardRAM_Memories_CompatibleRamId",
                        column: x => x.CompatibleRamId,
                        principalTable: "Memories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotherboardRAM_MotherBoards_CompatibleMotherboardsId",
                        column: x => x.CompatibleMotherboardsId,
                        principalTable: "MotherBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseMotherboard",
                columns: table => new
                {
                    CompatibleCasesId = table.Column<int>(type: "int", nullable: false),
                    CompatibleMotherboardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseMotherboard", x => new { x.CompatibleCasesId, x.CompatibleMotherboardsId });
                    table.ForeignKey(
                        name: "FK_CaseMotherboard_Cases_CompatibleCasesId",
                        column: x => x.CompatibleCasesId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseMotherboard_MotherBoards_CompatibleMotherboardsId",
                        column: x => x.CompatibleMotherboardsId,
                        principalTable: "MotherBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufactorer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EfficiencyRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wattage = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    GPUId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerSupplies_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PowerSupplies_GPUs_GPUId",
                        column: x => x.GPUId,
                        principalTable: "GPUs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StorageSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    MotherboardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageSlots_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageSlots_MotherBoards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "MotherBoards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Port",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MotherboardId = table.Column<int>(type: "int", nullable: true),
                    PowerSupplyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Port_MotherBoards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "MotherBoards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Port_PowerSupplies_PowerSupplyId",
                        column: x => x.PowerSupplyId,
                        principalTable: "PowerSupplies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseMotherboard_CompatibleMotherboardsId",
                table: "CaseMotherboard",
                column: "CompatibleMotherboardsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_GPUId",
                table: "Cases",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUCPUCooler_CompatibleCpusId",
                table: "CPUCPUCooler",
                column: "CompatibleCpusId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUMotherboard_CompatibleMotherboardsId",
                table: "CPUMotherboard",
                column: "CompatibleMotherboardsId");

            migrationBuilder.CreateIndex(
                name: "IX_CPURAM_CompatibleRamId",
                table: "CPURAM",
                column: "CompatibleRamId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUMotherboard_CompatibleMotherboardsId",
                table: "GPUMotherboard",
                column: "CompatibleMotherboardsId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardRAM_CompatibleRamId",
                table: "MotherboardRAM",
                column: "CompatibleRamId");

            migrationBuilder.CreateIndex(
                name: "IX_Port_MotherboardId",
                table: "Port",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Port_PowerSupplyId",
                table: "Port",
                column: "PowerSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplies_CaseId",
                table: "PowerSupplies",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplies_GPUId",
                table: "PowerSupplies",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Sockets_CPUCoolerId",
                table: "Sockets",
                column: "CPUCoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSlots_CaseId",
                table: "StorageSlots",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSlots_MotherboardId",
                table: "StorageSlots",
                column: "MotherboardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseMotherboard");

            migrationBuilder.DropTable(
                name: "CPUCPUCooler");

            migrationBuilder.DropTable(
                name: "CPUMotherboard");

            migrationBuilder.DropTable(
                name: "CPURAM");

            migrationBuilder.DropTable(
                name: "GPUMotherboard");

            migrationBuilder.DropTable(
                name: "MotherboardRAM");

            migrationBuilder.DropTable(
                name: "Port");

            migrationBuilder.DropTable(
                name: "Sockets");

            migrationBuilder.DropTable(
                name: "StorageSlots");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "Memories");

            migrationBuilder.DropTable(
                name: "PowerSupplies");

            migrationBuilder.DropTable(
                name: "CPUCoolers");

            migrationBuilder.DropTable(
                name: "MotherBoards");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "GPUs");
        }
    }
}
