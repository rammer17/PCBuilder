using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCompatibleCpusFromMemory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Memories_RAMId",
                table: "CPUs");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_RAMId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "RAMId",
                table: "CPUs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RAMId",
                table: "CPUs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_RAMId",
                table: "CPUs",
                column: "RAMId");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Memories_RAMId",
                table: "CPUs",
                column: "RAMId",
                principalTable: "Memories",
                principalColumn: "Id");
        }
    }
}
