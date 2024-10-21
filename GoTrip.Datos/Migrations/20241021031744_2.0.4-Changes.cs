using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTrip.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _204Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PathImagen",
                table: "PuntosTuristicos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PuntosTuristicos",
                keyColumn: "PathImagen",
                keyValue: null,
                column: "PathImagen",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PathImagen",
                table: "PuntosTuristicos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
