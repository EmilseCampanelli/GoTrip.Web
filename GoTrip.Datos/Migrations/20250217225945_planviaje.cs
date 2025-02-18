using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTrip.Datos.Migrations
{
    /// <inheritdoc />
    public partial class planviaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineaRecorridos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LineaRecorridos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventoId = table.Column<int>(type: "int", nullable: true),
                    PlanViajeId = table.Column<int>(type: "int", nullable: false),
                    PuntoTuristicoId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RecorridoId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
    }
}
