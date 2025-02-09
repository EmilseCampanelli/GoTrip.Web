using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTrip.Datos.Migrations
{
    /// <inheritdoc />
    public partial class changedev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_PlanViajes_PlanViajeId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_PuntosTuristicos_PlanViajes_PlanViajeId",
                table: "PuntosTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_PuntosTuristicos_PlanViajeId",
                table: "PuntosTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_PlanViajeId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "PlanViajeId",
                table: "PuntosTuristicos");

            migrationBuilder.DropColumn(
                name: "PlanViajeId",
                table: "Eventos");

            migrationBuilder.CreateTable(
                name: "LineaPuntoTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlanViajeId = table.Column<int>(type: "int", nullable: false),
                    PuntoTuristicoId = table.Column<int>(type: "int", nullable: true),
                    EventoId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaPuntoTuristicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineaPuntoTuristicos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineaPuntoTuristicos_PlanViajes_PlanViajeId",
                        column: x => x.PlanViajeId,
                        principalTable: "PlanViajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaPuntoTuristicos_PuntosTuristicos_PuntoTuristicoId",
                        column: x => x.PuntoTuristicoId,
                        principalTable: "PuntosTuristicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineaPuntoTuristicos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LineaRecorridos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventoId = table.Column<int>(type: "int", nullable: true),
                    PuntoTuristicoId = table.Column<int>(type: "int", nullable: true),
                    RecorridoId = table.Column<int>(type: "int", nullable: false),
                    PlanViajeId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaRecorridos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineaRecorridos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineaRecorridos_PlanViajes_PlanViajeId",
                        column: x => x.PlanViajeId,
                        principalTable: "PlanViajes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineaRecorridos_PuntosTuristicos_PuntoTuristicoId",
                        column: x => x.PuntoTuristicoId,
                        principalTable: "PuntosTuristicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineaRecorridos_Recorridos_RecorridoId",
                        column: x => x.RecorridoId,
                        principalTable: "Recorridos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaRecorridos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LineaPuntoTuristicos_EventoId",
                table: "LineaPuntoTuristicos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaPuntoTuristicos_PlanViajeId",
                table: "LineaPuntoTuristicos",
                column: "PlanViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaPuntoTuristicos_PuntoTuristicoId",
                table: "LineaPuntoTuristicos",
                column: "PuntoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaPuntoTuristicos_UsuarioId",
                table: "LineaPuntoTuristicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaRecorridos_EventoId",
                table: "LineaRecorridos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaRecorridos_PlanViajeId",
                table: "LineaRecorridos",
                column: "PlanViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaRecorridos_PuntoTuristicoId",
                table: "LineaRecorridos",
                column: "PuntoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaRecorridos_RecorridoId",
                table: "LineaRecorridos",
                column: "RecorridoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaRecorridos_UsuarioId",
                table: "LineaRecorridos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineaPuntoTuristicos");

            migrationBuilder.DropTable(
                name: "LineaRecorridos");

            migrationBuilder.AddColumn<int>(
                name: "PlanViajeId",
                table: "PuntosTuristicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanViajeId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PuntosTuristicos_PlanViajeId",
                table: "PuntosTuristicos",
                column: "PlanViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_PlanViajeId",
                table: "Eventos",
                column: "PlanViajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_PlanViajes_PlanViajeId",
                table: "Eventos",
                column: "PlanViajeId",
                principalTable: "PlanViajes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosTuristicos_PlanViajes_PlanViajeId",
                table: "PuntosTuristicos",
                column: "PlanViajeId",
                principalTable: "PlanViajes",
                principalColumn: "Id");
        }
    }
}
