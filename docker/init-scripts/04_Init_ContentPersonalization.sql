CREATE DATABASE IF NOT EXISTS `content_personalization`;
USE `content_personalization`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `estados_ruta` (
    `idEstadosRuta` int NOT NULL AUTO_INCREMENT,
    `nombre_estado` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idEstadosRuta`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `niveles_dificultad` (
    `idNivelesDificultad` int NOT NULL AUTO_INCREMENT,
    `nombre_nivel` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `valor_minimo` decimal(4,2) NOT NULL,
    `valor_maximo` decimal(4,2) NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idNivelesDificultad`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tipos_contenido` (
    `idTiposContenido` int NOT NULL AUTO_INCREMENT,
    `nombre_tipo` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idTiposContenido`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `rutas_aprendizaje` (
    `idRutasAprendizaje` int NOT NULL AUTO_INCREMENT,
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `nombre_ruta` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `idEstadosRuta` int NOT NULL,
    `fecha_creacion` timestamp NOT NULL,
    `fecha_actualizacion` timestamp NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idRutasAprendizaje`),
    CONSTRAINT `fk_rutas_aprendizaje_estados_ruta1` FOREIGN KEY (`idEstadosRuta`) REFERENCES `estados_ruta` (`idEstadosRuta`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `contenidos_educativos` (
    `idContenidosEducativos` int NOT NULL AUTO_INCREMENT,
    `codigo_contenido` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `titulo` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `idTiposContenido` int NOT NULL,
    `idNivelesDificultad` int NOT NULL,
    `duracion_minutos` int NOT NULL,
    `url_recurso` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `etiquetas_json` json NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idContenidosEducativos`),
    CONSTRAINT `fk_contenidos_educativos_niveles_dificultad1` FOREIGN KEY (`idNivelesDificultad`) REFERENCES `niveles_dificultad` (`idNivelesDificultad`),
    CONSTRAINT `fk_contenidos_educativos_tipos_contenido` FOREIGN KEY (`idTiposContenido`) REFERENCES `tipos_contenido` (`idTiposContenido`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `modelos_ruta` (
    `idModelosRuta` int NOT NULL AUTO_INCREMENT,
    `idRutasAprendizaje` int NOT NULL,
    `idContenido` int NOT NULL,
    `orden_modulo` int NOT NULL,
    `fecha_asignacion` timestamp NOT NULL,
    `fecha_completacion` timestamp NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idModelosRuta`),
    CONSTRAINT `fk_modelos_ruta_rutas_aprendizaje1` FOREIGN KEY (`idRutasAprendizaje`) REFERENCES `rutas_aprendizaje` (`idRutasAprendizaje`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE UNIQUE INDEX `codigo_contenido_UNIQUE` ON `contenidos_educativos` (`codigo_contenido`);

CREATE INDEX `fk_contenidos_educativos_niveles_dificultad1_idx` ON `contenidos_educativos` (`idNivelesDificultad`);

CREATE INDEX `fk_contenidos_educativos_tipos_contenido_idx` ON `contenidos_educativos` (`idTiposContenido`);

CREATE INDEX `fk_modelos_ruta_rutas_aprendizaje1_idx` ON `modelos_ruta` (`idRutasAprendizaje`);

CREATE INDEX `fk_rutas_aprendizaje_estados_ruta1_idx` ON `rutas_aprendizaje` (`idEstadosRuta`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260603172105_InitialCreate', '8.0.13');

COMMIT;

