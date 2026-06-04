CREATE DATABASE IF NOT EXISTS `competency_mapping`;
USE `competency_mapping`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `categorias_competencia` (
    `idCategoriasCompetencia` int NOT NULL AUTO_INCREMENT,
    `nombre_categoria` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idCategoriasCompetencia`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `estados_dominio` (
    `idEstadosDominio` int NOT NULL AUTO_INCREMENT,
    `nombre_estado` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idEstadosDominio`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `niveles_prioridad` (
    `idNivelesPrioridad` int NOT NULL AUTO_INCREMENT,
    `nombre_prioridad` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `valor_prioridad` int NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idNivelesPrioridad`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `mapa_competencias_estudiante` (
    `idMapaCompetenciasEstudiante` int NOT NULL AUTO_INCREMENT,
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `idCompetencias` int NOT NULL,
    `nivel_dominio` decimal(4,2) NOT NULL,
    `idEstadosDominio` int NOT NULL,
    `confianza` decimal(4,2) NOT NULL,
    `fecha_evaluacion` timestamp NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idMapaCompetenciasEstudiante`),
    CONSTRAINT `fk_mapa_competencias_estudiante_estados_dominio1` FOREIGN KEY (`idEstadosDominio`) REFERENCES `estados_dominio` (`idEstadosDominio`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `brechas_aprendizaje` (
    `idBrechasAprendizaje` int NOT NULL AUTO_INCREMENT,
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `idCompetencias` int NOT NULL,
    `nivel_actual` decimal(4,2) NOT NULL,
    `nivel_requerido` decimal(4,2) NOT NULL,
    `idNivelesPrioridad` int NOT NULL,
    `fecha_deteccion` timestamp NOT NULL,
    `es_activa` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idBrechasAprendizaje`),
    CONSTRAINT `fk_brechas_aprendizaje_niveles_prioridad1` FOREIGN KEY (`idNivelesPrioridad`) REFERENCES `niveles_prioridad` (`idNivelesPrioridad`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE INDEX `fk_brechas_aprendizaje_Competencias1_idx` ON `brechas_aprendizaje` (`idCompetencias`);

CREATE INDEX `fk_brechas_aprendizaje_niveles_prioridad1_idx` ON `brechas_aprendizaje` (`idNivelesPrioridad`);

CREATE INDEX `fk_mapa_competencias_estudiante_Competencias1_idx` ON `mapa_competencias_estudiante` (`idCompetencias`);

CREATE INDEX `fk_mapa_competencias_estudiante_estados_dominio1_idx` ON `mapa_competencias_estudiante` (`idEstadosDominio`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260603172057_InitialCreate', '8.0.13');

COMMIT;

