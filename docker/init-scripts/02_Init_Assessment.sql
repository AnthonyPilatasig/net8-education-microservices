CREATE DATABASE IF NOT EXISTS `assessment`;
USE `assessment`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `tipos_evaluacion` (
    `idTiposEvaluacion` int NOT NULL AUTO_INCREMENT,
    `nombre_tipo` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idTiposEvaluacion`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tipos_pregunta` (
    `idTiposPregunta` int NOT NULL AUTO_INCREMENT,
    `nombre_tipo` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idTiposPregunta`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `evaluaciones` (
    `idEvaluaciones` int NOT NULL AUTO_INCREMENT,
    `codigo_evaluacion` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `titulo` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `idTiposEvaluacion` int NOT NULL,
    `idNivelesDificultad` int NOT NULL,
    `tiempo_estimado_minutos` int NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idEvaluaciones`),
    CONSTRAINT `fk_evaluaciones_tipos_evaluacion` FOREIGN KEY (`idTiposEvaluacion`) REFERENCES `tipos_evaluacion` (`idTiposEvaluacion`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `preguntas` (
    `idPreguntas` int NOT NULL AUTO_INCREMENT,
    `idEvaluaciones` int NOT NULL,
    `idTiposPregunta` int NOT NULL,
    `texto_pregunta` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `preguntas_json` json NOT NULL,
    `respuesta_correcta` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `orden_pregunta` int NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idPreguntas`),
    CONSTRAINT `fk_preguntas_evaluaciones1` FOREIGN KEY (`idEvaluaciones`) REFERENCES `evaluaciones` (`idEvaluaciones`),
    CONSTRAINT `fk_preguntas_tipos_pregunta1` FOREIGN KEY (`idTiposPregunta`) REFERENCES `tipos_pregunta` (`idTiposPregunta`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `resultados_evaluacion` (
    `idResultadosEvaluacion` int NOT NULL AUTO_INCREMENT,
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `idEvaluaciones` int NOT NULL,
    `puntaje_obtenido` decimal(6,2) NOT NULL,
    `puntaje_maximo` decimal(6,2) NOT NULL,
    `tiempo_empleado_minutos` int NOT NULL,
    `fecha_completacion` timestamp NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idResultadosEvaluacion`),
    CONSTRAINT `fk_resultados_evaluacion_evaluaciones1` FOREIGN KEY (`idEvaluaciones`) REFERENCES `evaluaciones` (`idEvaluaciones`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE INDEX `fk_evaluaciones_niveles_dificultad1_idx` ON `evaluaciones` (`idNivelesDificultad`);

CREATE INDEX `fk_evaluaciones_tipos_evaluacion_idx` ON `evaluaciones` (`idTiposEvaluacion`);

CREATE INDEX `fk_preguntas_evaluaciones1_idx` ON `preguntas` (`idEvaluaciones`);

CREATE INDEX `fk_preguntas_tipos_pregunta1_idx` ON `preguntas` (`idTiposPregunta`);

CREATE INDEX `fk_resultados_evaluacion_evaluaciones1_idx` ON `resultados_evaluacion` (`idEvaluaciones`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260603172050_InitialCreate', '8.0.13');

COMMIT;

