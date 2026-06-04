using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment.Service.Migrations
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
                name: "tipos_evaluacion",
                columns: table => new
                {
                    idTiposEvaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_tipo = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idTiposEvaluacion);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tipos_pregunta",
                columns: table => new
                {
                    idTiposPregunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_tipo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idTiposPregunta);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "evaluaciones",
                columns: table => new
                {
                    idEvaluaciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_evaluacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    titulo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idTiposEvaluacion = table.Column<int>(type: "int", nullable: false),
                    idNivelesDificultad = table.Column<int>(type: "int", nullable: false),
                    tiempo_estimado_minutos = table.Column<int>(type: "int", nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idEvaluaciones);
                    table.ForeignKey(
                        name: "fk_evaluaciones_tipos_evaluacion",
                        column: x => x.idTiposEvaluacion,
                        principalTable: "tipos_evaluacion",
                        principalColumn: "idTiposEvaluacion");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "preguntas",
                columns: table => new
                {
                    idPreguntas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idEvaluaciones = table.Column<int>(type: "int", nullable: false),
                    idTiposPregunta = table.Column<int>(type: "int", nullable: false),
                    texto_pregunta = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    preguntas_json = table.Column<string>(type: "json", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    respuesta_correcta = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    orden_pregunta = table.Column<int>(type: "int", nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idPreguntas);
                    table.ForeignKey(
                        name: "fk_preguntas_evaluaciones1",
                        column: x => x.idEvaluaciones,
                        principalTable: "evaluaciones",
                        principalColumn: "idEvaluaciones");
                    table.ForeignKey(
                        name: "fk_preguntas_tipos_pregunta1",
                        column: x => x.idTiposPregunta,
                        principalTable: "tipos_pregunta",
                        principalColumn: "idTiposPregunta");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "resultados_evaluacion",
                columns: table => new
                {
                    idResultadosEvaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idEstudiante = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idEvaluaciones = table.Column<int>(type: "int", nullable: false),
                    puntaje_obtenido = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    puntaje_maximo = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    tiempo_empleado_minutos = table.Column<int>(type: "int", nullable: false),
                    fecha_completacion = table.Column<DateTime>(type: "timestamp", nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idResultadosEvaluacion);
                    table.ForeignKey(
                        name: "fk_resultados_evaluacion_evaluaciones1",
                        column: x => x.idEvaluaciones,
                        principalTable: "evaluaciones",
                        principalColumn: "idEvaluaciones");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "fk_evaluaciones_niveles_dificultad1_idx",
                table: "evaluaciones",
                column: "idNivelesDificultad");

            migrationBuilder.CreateIndex(
                name: "fk_evaluaciones_tipos_evaluacion_idx",
                table: "evaluaciones",
                column: "idTiposEvaluacion");

            migrationBuilder.CreateIndex(
                name: "fk_preguntas_evaluaciones1_idx",
                table: "preguntas",
                column: "idEvaluaciones");

            migrationBuilder.CreateIndex(
                name: "fk_preguntas_tipos_pregunta1_idx",
                table: "preguntas",
                column: "idTiposPregunta");

            migrationBuilder.CreateIndex(
                name: "fk_resultados_evaluacion_evaluaciones1_idx",
                table: "resultados_evaluacion",
                column: "idEvaluaciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "preguntas");

            migrationBuilder.DropTable(
                name: "resultados_evaluacion");

            migrationBuilder.DropTable(
                name: "tipos_pregunta");

            migrationBuilder.DropTable(
                name: "evaluaciones");

            migrationBuilder.DropTable(
                name: "tipos_evaluacion");
        }
    }
}
