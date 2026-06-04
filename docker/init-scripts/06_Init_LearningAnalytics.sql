CREATE DATABASE IF NOT EXISTS `learning_analytics`;
USE `learning_analytics`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `metricas_compromiso` (
    `idMetricasCompromiso` int NOT NULL AUTO_INCREMENT,
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `puntaje_compromiso` decimal(5,2) NOT NULL DEFAULT '0.00',
    `tiempo_total_minutos` int NOT NULL,
    `contenido_completado` int NOT NULL,
    `fecha_calculo` timestamp NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idMetricasCompromiso`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `sesiones_aprendizaje` (
    `idSesionesAprendizaje` int NOT NULL AUTO_INCREMENT,
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `fecha_inicio` timestamp NOT NULL,
    `fecha_fin` timestamp NULL,
    `duracion_minutos` int NOT NULL,
    `actividades_completadas` int NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idSesionesAprendizaje`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tipo_evento` (
    `idTipoEvento` int NOT NULL AUTO_INCREMENT,
    `nombre_evento` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idTipoEvento`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `eventos_aprendizaje` (
    `idEventosAprendizaje` int NOT NULL AUTO_INCREMENT,
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `idContenido` int NOT NULL,
    `idTipoEvento` int NOT NULL,
    `fecha_evento` timestamp NOT NULL,
    `metadatos_json` json NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idEventosAprendizaje`),
    CONSTRAINT `fk_eventos_aprendizaje_TipoEvento` FOREIGN KEY (`idTipoEvento`) REFERENCES `tipo_evento` (`idTipoEvento`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE INDEX `fk_eventos_aprendizaje_TipoEvento_idx` ON `eventos_aprendizaje` (`idTipoEvento`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260603172120_InitialCreate', '8.0.13');

COMMIT;

