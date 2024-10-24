using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTrip.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _203Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ubicaciones_Localidades_LocalidadId",
                table: "Ubicaciones");

            migrationBuilder.DropTable(
                name: "EventoRecorrido");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "PuntoTuristicoRecorrido");

            migrationBuilder.DropIndex(
                name: "IX_Ubicaciones_LocalidadId",
                table: "Ubicaciones");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "Ubicaciones");

            migrationBuilder.RenameColumn(
                name: "Descriocion",
                table: "PlanViajes",
                newName: "Descripcion");

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Ubicaciones",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Ubicaciones",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Ubicaciones",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PathImagen",
                table: "PuntosTuristicos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PlanViajeId",
                table: "PuntosTuristicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecorridoId",
                table: "PuntosTuristicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PathImagen",
                table: "Eventos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PlanViajeId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecorridoId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CantidadEstrellas = table.Column<int>(type: "int", nullable: false),
                    PuntoTuristicoId = table.Column<int>(type: "int", nullable: true),
                    EventoId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentario_PuntosTuristicos_PuntoTuristicoId",
                        column: x => x.PuntoTuristicoId,
                        principalTable: "PuntosTuristicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PuntosTuristicos_PlanViajeId",
                table: "PuntosTuristicos",
                column: "PlanViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntosTuristicos_RecorridoId",
                table: "PuntosTuristicos",
                column: "RecorridoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_CategoriaId",
                table: "Eventos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_PlanViajeId",
                table: "Eventos",
                column: "PlanViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_RecorridoId",
                table: "Eventos",
                column: "RecorridoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_EventoId",
                table: "Comentario",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PuntoTuristicoId",
                table: "Comentario",
                column: "PuntoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioId",
                table: "Comentario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Categorias_CategoriaId",
                table: "Eventos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_PlanViajes_PlanViajeId",
                table: "Eventos",
                column: "PlanViajeId",
                principalTable: "PlanViajes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Recorridos_RecorridoId",
                table: "Eventos",
                column: "RecorridoId",
                principalTable: "Recorridos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosTuristicos_PlanViajes_PlanViajeId",
                table: "PuntosTuristicos",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Categorias_CategoriaId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_PlanViajes_PlanViajeId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Recorridos_RecorridoId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_PuntosTuristicos_PlanViajes_PlanViajeId",
                table: "PuntosTuristicos");

            migrationBuilder.DropForeignKey(
                name: "FK_PuntosTuristicos_Recorridos_RecorridoId",
                table: "PuntosTuristicos");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_PuntosTuristicos_PlanViajeId",
                table: "PuntosTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_PuntosTuristicos_RecorridoId",
                table: "PuntosTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_CategoriaId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_PlanViajeId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_RecorridoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Ubicaciones");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Ubicaciones");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Ubicaciones");

            migrationBuilder.DropColumn(
                name: "PathImagen",
                table: "PuntosTuristicos");

            migrationBuilder.DropColumn(
                name: "PlanViajeId",
                table: "PuntosTuristicos");

            migrationBuilder.DropColumn(
                name: "RecorridoId",
                table: "PuntosTuristicos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "PathImagen",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "PlanViajeId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "RecorridoId",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "PlanViajes",
                newName: "Descriocion");

            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "Ubicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventoRecorrido",
                columns: table => new
                {
                    EventosId = table.Column<int>(type: "int", nullable: false),
                    RecorridosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoRecorrido", x => new { x.EventosId, x.RecorridosId });
                    table.ForeignKey(
                        name: "FK_EventoRecorrido_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoRecorrido_Recorridos_RecorridosId",
                        column: x => x.RecorridosId,
                        principalTable: "Recorridos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PuntoTuristicoRecorrido",
                columns: table => new
                {
                    PuntoTuristicosId = table.Column<int>(type: "int", nullable: false),
                    RecorridosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoTuristicoRecorrido", x => new { x.PuntoTuristicosId, x.RecorridosId });
                    table.ForeignKey(
                        name: "FK_PuntoTuristicoRecorrido_PuntosTuristicos_PuntoTuristicosId",
                        column: x => x.PuntoTuristicosId,
                        principalTable: "PuntosTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuntoTuristicoRecorrido_Recorridos_RecorridosId",
                        column: x => x.RecorridosId,
                        principalTable: "Recorridos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicaciones_LocalidadId",
                table: "Ubicaciones",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoRecorrido_RecorridosId",
                table: "EventoRecorrido",
                column: "RecorridosId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_UsuarioId",
                table: "Localidades",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoTuristicoRecorrido_RecorridosId",
                table: "PuntoTuristicoRecorrido",
                column: "RecorridosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ubicaciones_Localidades_LocalidadId",
                table: "Ubicaciones",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
