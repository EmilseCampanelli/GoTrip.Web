using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTrip.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _202changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuntosTuristicos_Categorias_CategoriaId",
                table: "PuntosTuristicos");

            migrationBuilder.DropForeignKey(
                name: "FK_PuntosTuristicos_Ubicaciones_UbicacionId",
                table: "PuntosTuristicos");

            migrationBuilder.AlterColumn<int>(
                name: "UbicacionId",
                table: "PuntosTuristicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "PuntosTuristicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosTuristicos_Categorias_CategoriaId",
                table: "PuntosTuristicos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosTuristicos_Ubicaciones_UbicacionId",
                table: "PuntosTuristicos",
                column: "UbicacionId",
                principalTable: "Ubicaciones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuntosTuristicos_Categorias_CategoriaId",
                table: "PuntosTuristicos");

            migrationBuilder.DropForeignKey(
                name: "FK_PuntosTuristicos_Ubicaciones_UbicacionId",
                table: "PuntosTuristicos");

            migrationBuilder.AlterColumn<int>(
                name: "UbicacionId",
                table: "PuntosTuristicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "PuntosTuristicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosTuristicos_Categorias_CategoriaId",
                table: "PuntosTuristicos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosTuristicos_Ubicaciones_UbicacionId",
                table: "PuntosTuristicos",
                column: "UbicacionId",
                principalTable: "Ubicaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
