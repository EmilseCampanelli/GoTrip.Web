using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTrip.Datos.Migrations
{
    /// <inheritdoc />
    public partial class newChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Recorridos_RecorridoId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaRecorridos_PlanViajes_PlanViajeId",
                table: "LineaRecorridos");

            migrationBuilder.DropForeignKey(
                name: "FK_PuntosTuristicos_Recorridos_RecorridoId",
                table: "PuntosTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_PuntosTuristicos_RecorridoId",
                table: "PuntosTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_LineaRecorridos_PlanViajeId",
                table: "LineaRecorridos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_RecorridoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "RecorridoId",
                table: "PuntosTuristicos");

            migrationBuilder.DropColumn(
                name: "PlanViajeId",
                table: "LineaRecorridos");

            migrationBuilder.DropColumn(
                name: "RecorridoId",
                table: "Eventos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecorridoId",
                table: "PuntosTuristicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanViajeId",
                table: "LineaRecorridos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecorridoId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PuntosTuristicos_RecorridoId",
                table: "PuntosTuristicos",
                column: "RecorridoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaRecorridos_PlanViajeId",
                table: "LineaRecorridos",
                column: "PlanViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_RecorridoId",
                table: "Eventos",
                column: "RecorridoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Recorridos_RecorridoId",
                table: "Eventos",
                column: "RecorridoId",
                principalTable: "Recorridos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaRecorridos_PlanViajes_PlanViajeId",
                table: "LineaRecorridos",
                column: "PlanViajeId",
                principalTable: "PlanViajes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosTuristicos_Recorridos_RecorridoId",
                table: "PuntosTuristicos",
                column: "RecorridoId",
                principalTable: "Recorridos",
                principalColumn: "Id");
        }
    }
}
