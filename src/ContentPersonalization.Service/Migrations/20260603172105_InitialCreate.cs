using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContentPersonalization.Service.Migrations
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
                name: "estados_ruta",
                columns: table => new
                {
                    idEstadosRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_estado = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idEstadosRuta);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "niveles_dificultad",
                columns: table => new
                {
                    idNivelesDificultad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_nivel = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valor_minimo = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    valor_maximo = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idNivelesDificultad);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tipos_contenido",
                columns: table => new
                {
                    idTiposContenido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_tipo = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idTiposContenido);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "rutas_aprendizaje",
                columns: table => new
                {
                    idRutasAprendizaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idEstudiante = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre_ruta = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idEstadosRuta = table.Column<int>(type: "int", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamp", nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "timestamp", nullable: false),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idRutasAprendizaje);
                    table.ForeignKey(
                        name: "fk_rutas_aprendizaje_estados_ruta1",
                        column: x => x.idEstadosRuta,
                        principalTable: "estados_ruta",
                        principalColumn: "idEstadosRuta");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "contenidos_educativos",
                columns: table => new
                {
                    idContenidosEducativos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_contenido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    titulo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idTiposContenido = table.Column<int>(type: "int", nullable: false),
                    idNivelesDificultad = table.Column<int>(type: "int", nullable: false),
                    duracion_minutos = table.Column<int>(type: "int", nullable: false),
                    url_recurso = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    etiquetas_json = table.Column<string>(type: "json", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idContenidosEducativos);
                    table.ForeignKey(
                        name: "fk_contenidos_educativos_niveles_dificultad1",
                        column: x => x.idNivelesDificultad,
                        principalTable: "niveles_dificultad",
                        principalColumn: "idNivelesDificultad");
                    table.ForeignKey(
                        name: "fk_contenidos_educativos_tipos_contenido",
                        column: x => x.idTiposContenido,
                        principalTable: "tipos_contenido",
                        principalColumn: "idTiposContenido");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "modelos_ruta",
                columns: table => new
                {
                    idModelosRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idRutasAprendizaje = table.Column<int>(type: "int", nullable: false),
                    idContenido = table.Column<int>(type: "int", nullable: false),
                    orden_modulo = table.Column<int>(type: "int", nullable: false),
                    fecha_asignacion = table.Column<DateTime>(type: "timestamp", nullable: false),
                    fecha_completacion = table.Column<DateTime>(type: "timestamp", nullable: true),
                    es_activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idModelosRuta);
                    table.ForeignKey(
                        name: "fk_modelos_ruta_rutas_aprendizaje1",
                        column: x => x.idRutasAprendizaje,
                        principalTable: "rutas_aprendizaje",
                        principalColumn: "idRutasAprendizaje");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "codigo_contenido_UNIQUE",
                table: "contenidos_educativos",
                column: "codigo_contenido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_contenidos_educativos_niveles_dificultad1_idx",
                table: "contenidos_educativos",
                column: "idNivelesDificultad");

            migrationBuilder.CreateIndex(
                name: "fk_contenidos_educativos_tipos_contenido_idx",
                table: "contenidos_educativos",
                column: "idTiposContenido");

            migrationBuilder.CreateIndex(
                name: "fk_modelos_ruta_rutas_aprendizaje1_idx",
                table: "modelos_ruta",
                column: "idRutasAprendizaje");

            migrationBuilder.CreateIndex(
                name: "fk_rutas_aprendizaje_estados_ruta1_idx",
                table: "rutas_aprendizaje",
                column: "idEstadosRuta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contenidos_educativos");

            migrationBuilder.DropTable(
                name: "modelos_ruta");

            migrationBuilder.DropTable(
                name: "niveles_dificultad");

            migrationBuilder.DropTable(
                name: "tipos_contenido");

            migrationBuilder.DropTable(
                name: "rutas_aprendizaje");

            migrationBuilder.DropTable(
                name: "estados_ruta");
        }
    }
}
