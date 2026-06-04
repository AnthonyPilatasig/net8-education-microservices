using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAnalytics.Service.Migrations
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
                name: "metricas_compromiso",
                columns: table => new
                {
                    idMetricasCompromiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idEstudiante = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    puntaje_compromiso = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false, defaultValueSql: "'0.00'"),
                    tiempo_total_minutos = table.Column<int>(type: "int", nullable: false),
                    contenido_completado = table.Column<int>(type: "int", nullable: false),
                    fecha_calculo = table.Column<DateTime>(type: "timestamp", nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idMetricasCompromiso);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "sesiones_aprendizaje",
                columns: table => new
                {
                    idSesionesAprendizaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idEstudiante = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_inicio = table.Column<DateTime>(type: "timestamp", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "timestamp", nullable: true),
                    duracion_minutos = table.Column<int>(type: "int", nullable: false),
                    actividades_completadas = table.Column<int>(type: "int", nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idSesionesAprendizaje);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tipo_evento",
                columns: table => new
                {
                    idTipoEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_evento = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idTipoEvento);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "eventos_aprendizaje",
                columns: table => new
                {
                    idEventosAprendizaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idEstudiante = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idContenido = table.Column<int>(type: "int", nullable: false),
                    idTipoEvento = table.Column<int>(type: "int", nullable: false),
                    fecha_evento = table.Column<DateTime>(type: "timestamp", nullable: false),
                    metadatos_json = table.Column<string>(type: "json", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idEventosAprendizaje);
                    table.ForeignKey(
                        name: "fk_eventos_aprendizaje_TipoEvento",
                        column: x => x.idTipoEvento,
                        principalTable: "tipo_evento",
                        principalColumn: "idTipoEvento");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "fk_eventos_aprendizaje_TipoEvento_idx",
                table: "eventos_aprendizaje",
                column: "idTipoEvento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventos_aprendizaje");

            migrationBuilder.DropTable(
                name: "metricas_compromiso");

            migrationBuilder.DropTable(
                name: "sesiones_aprendizaje");

            migrationBuilder.DropTable(
                name: "tipo_evento");
        }
    }
}
