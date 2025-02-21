using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTrip.Datos.Migrations
{
    /// <inheritdoc />
    public partial class finalv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Ubicaciones_UbicacionId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_PuntosTuristicos_Ubicaciones_UbicacionId",
                table: "PuntosTuristicos");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_PuntosTuristicos_UbicacionId",
                table: "PuntosTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_UbicacionId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "UbicacionId",
                table: "PuntosTuristicos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PlanViajes");

            migrationBuilder.DropColumn(
                name: "UbicacionId",
                table: "Eventos");

            migrationBuilder.AddColumn<double>(
                name: "Documento",
                table: "Usuarios",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Latitud",
                table: "PuntosTuristicos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Longitud",
                table: "PuntosTuristicos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "PuntosTuristicos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Latitud",
                table: "Eventos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Longitud",
                table: "Eventos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Eventos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "PuntosTuristicos");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "PuntosTuristicos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "PuntosTuristicos");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "UbicacionId",
                table: "PuntosTuristicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "PlanViajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UbicacionId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventoId = table.Column<int>(type: "int", nullable: true),
                    PuntoTuristicoId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CantidadEstrellas = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                name: "IX_PuntosTuristicos_UbicacionId",
                table: "PuntosTuristicos",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UbicacionId",
                table: "Eventos",
                column: "UbicacionId");

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
                name: "FK_Eventos_Ubicaciones_UbicacionId",
                table: "Eventos",
                column: "UbicacionId",
                principalTable: "Ubicaciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosTuristicos_Ubicaciones_UbicacionId",
                table: "PuntosTuristicos",
                column: "UbicacionId",
                principalTable: "Ubicaciones",
                principalColumn: "Id");
        }
    }
}
