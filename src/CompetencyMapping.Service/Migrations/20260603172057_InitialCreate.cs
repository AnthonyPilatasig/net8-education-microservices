using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetencyMapping.Service.Migrations
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
                name: "categorias_competencia",
                columns: table => new
                {
                    idCategoriasCompetencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_categoria = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idCategoriasCompetencia);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "estados_dominio",
                columns: table => new
                {
                    idEstadosDominio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_estado = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idEstadosDominio);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "niveles_prioridad",
                columns: table => new
                {
                    idNivelesPrioridad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_prioridad = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valor_prioridad = table.Column<int>(type: "int", nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idNivelesPrioridad);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "mapa_competencias_estudiante",
                columns: table => new
                {
                    idMapaCompetenciasEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idEstudiante = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idCompetencias = table.Column<int>(type: "int", nullable: false),
                    nivel_dominio = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    idEstadosDominio = table.Column<int>(type: "int", nullable: false),
                    confianza = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    fecha_evaluacion = table.Column<DateTime>(type: "timestamp", nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idMapaCompetenciasEstudiante);
                    table.ForeignKey(
                        name: "fk_mapa_competencias_estudiante_estados_dominio1",
                        column: x => x.idEstadosDominio,
                        principalTable: "estados_dominio",
                        principalColumn: "idEstadosDominio");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "brechas_aprendizaje",
                columns: table => new
                {
                    idBrechasAprendizaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idEstudiante = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idCompetencias = table.Column<int>(type: "int", nullable: false),
                    nivel_actual = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    nivel_requerido = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    idNivelesPrioridad = table.Column<int>(type: "int", nullable: false),
                    fecha_deteccion = table.Column<DateTime>(type: "timestamp", nullable: false),
                    es_activa = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idBrechasAprendizaje);
                    table.ForeignKey(
                        name: "fk_brechas_aprendizaje_niveles_prioridad1",
                        column: x => x.idNivelesPrioridad,
                        principalTable: "niveles_prioridad",
                        principalColumn: "idNivelesPrioridad");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "fk_brechas_aprendizaje_Competencias1_idx",
                table: "brechas_aprendizaje",
                column: "idCompetencias");

            migrationBuilder.CreateIndex(
                name: "fk_brechas_aprendizaje_niveles_prioridad1_idx",
                table: "brechas_aprendizaje",
                column: "idNivelesPrioridad");

            migrationBuilder.CreateIndex(
                name: "fk_mapa_competencias_estudiante_Competencias1_idx",
                table: "mapa_competencias_estudiante",
                column: "idCompetencias");

            migrationBuilder.CreateIndex(
                name: "fk_mapa_competencias_estudiante_estados_dominio1_idx",
                table: "mapa_competencias_estudiante",
                column: "idEstadosDominio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brechas_aprendizaje");

            migrationBuilder.DropTable(
                name: "categorias_competencia");

            migrationBuilder.DropTable(
                name: "mapa_competencias_estudiante");

            migrationBuilder.DropTable(
                name: "niveles_prioridad");

            migrationBuilder.DropTable(
                name: "estados_dominio");
        }
    }
}
