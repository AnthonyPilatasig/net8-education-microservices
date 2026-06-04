CREATE DATABASE IF NOT EXISTS `education_platform`;
USE `education_platform`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `cursos` (
    `idCursos` int NOT NULL AUTO_INCREMENT,
    `codigo_curso` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `nombre_curso` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descripcion` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `duracion_horas` decimal(5,2) NOT NULL,
    `nivel_dificultad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `categoria` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idCursos`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `estudiantes` (
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `codigo_estudiante` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `primer_nombre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `segundo_nombre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `primer_apellido` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `segundo_apellido` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `email` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `fecha_registro` timestamp NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idEstudiante`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `inscripciones` (
    `idInscripciones` int NOT NULL AUTO_INCREMENT,
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `idCursos` int NOT NULL,
    `fecha_inscripcion` timestamp NOT NULL,
    `estado_inscripcion` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'ACTIVA',
    `progreso_porcentaje` decimal(5,2) NOT NULL DEFAULT '0.00',
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idInscripciones`),
    CONSTRAINT `fk_inscripciones_cursos1` FOREIGN KEY (`idCursos`) REFERENCES `cursos` (`idCursos`),
    CONSTRAINT `fk_inscripciones_usuario_estudiante1` FOREIGN KEY (`idEstudiante`) REFERENCES `estudiantes` (`idEstudiante`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `usuario_estudiante` (
    `idEstudiante` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `contraseña` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `fecha_creacion` timestamp NOT NULL,
    `es_activo` tinyint(1) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idEstudiante`),
    CONSTRAINT `fk_usuario_estudiante_estudiantes` FOREIGN KEY (`idEstudiante`) REFERENCES `estudiantes` (`idEstudiante`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE UNIQUE INDEX `codigo_curso_UNIQUE` ON `cursos` (`codigo_curso`);

CREATE UNIQUE INDEX `idEstudiante_UNIQUE` ON `estudiantes` (`idEstudiante`);

CREATE INDEX `fk_inscripciones_cursos1_idx` ON `inscripciones` (`idCursos`);

CREATE INDEX `fk_inscripciones_usuario_estudiante1_idx` ON `inscripciones` (`idEstudiante`);

CREATE UNIQUE INDEX `fk_usuario_estudiante_estudiantes_idx` ON `usuario_estudiante` (`idEstudiante`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260603172025_InitialCreate', '8.0.13');

COMMIT;

