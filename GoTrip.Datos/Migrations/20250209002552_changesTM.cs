using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTrip.Datos.Migrations
{
    /// <inheritdoc />
    public partial class changesTM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanViajeId",
                table: "LineaRecorridos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LineaRecorridos_PlanViajeId",
                table: "LineaRecorridos",
                column: "PlanViajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaRecorridos_PlanViajes_PlanViajeId",
                table: "LineaRecorridos",
                column: "PlanViajeId",
                principalTable: "PlanViajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaRecorridos_PlanViajes_PlanViajeId",
                table: "LineaRecorridos");

            migrationBuilder.DropIndex(
                name: "IX_LineaRecorridos_PlanViajeId",
                table: "LineaRecorridos");

            migrationBuilder.DropColumn(
                name: "PlanViajeId",
                table: "LineaRecorridos");
        }
    }
}
