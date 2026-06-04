CREATE DATABASE IF NOT EXISTS `adaptive_engine`;
USE `adaptive_engine`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `estilos_aprendizaje` (
    `idEstilosAprendizaje` int NOT NULL AUTO_INCREMENT,
    `nombre_estilo` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idEstilosAprendizaje`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `perfiles_estudiantes` (
    `idPerfilesEstudiantes` int NOT NULL AUTO_INCREMENT,
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `idEstilosAprendizaje` int NOT NULL,
    `nivel_actual` decimal(4,2) NOT NULL,
    `velocidad_aprendizaje` decimal(4,2) NOT NULL,
    `fecha_actualizacion` timestamp NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idPerfilesEstudiantes`),
    CONSTRAINT `fk_perfiles_estudiantes_estilos_aprendizaje` FOREIGN KEY (`idEstilosAprendizaje`) REFERENCES `estilos_aprendizaje` (`idEstilosAprendizaje`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE INDEX `fk_perfiles_estudiantes_estilos_aprendizaje_idx` ON `perfiles_estudiantes` (`idEstilosAprendizaje`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260603172113_InitialCreate', '8.0.13');

COMMIT;

