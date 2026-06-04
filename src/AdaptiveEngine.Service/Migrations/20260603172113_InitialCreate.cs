using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdaptiveEngine.Service.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estilos_aprendizaje",
                columns: table => new
                {
                    idEstilosAprendizaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_estilo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idEstilosAprendizaje);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "perfiles_estudiantes",
                columns: table => new
                {
                    idPerfilesEstudiantes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idEstudiante = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idEstilosAprendizaje = table.Column<int>(type: "int", nullable: false),
                    nivel_actual = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    velocidad_aprendizaje = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "timestamp", nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idPerfilesEstudiantes);
                    table.ForeignKey(
                        name: "fk_perfiles_estudiantes_estilos_aprendizaje",
                        column: x => x.idEstilosAprendizaje,
                        principalTable: "estilos_aprendizaje",
                        principalColumn: "idEstilosAprendizaje");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "fk_perfiles_estudiantes_estilos_aprendizaje_idx",
                table: "perfiles_estudiantes",
                column: "idEstilosAprendizaje");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfiles_estudiantes");

            migrationBuilder.DropTable(
                name: "estilos_aprendizaje");
        }
    }
}
