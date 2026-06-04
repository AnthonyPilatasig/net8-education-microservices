USE `education_platform`;

INSERT IGNORE INTO estudiantes (idEstudiante, codigo_estudiante, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, email, fecha_registro, es_activo) VALUES
('EST-001', 'COD-001', 'Juan', 'Carlos', 'Perez', 'Gomez', 'juan.perez@example.com', NOW(), 1),
('EST-002', 'COD-002', 'Maria', 'Jose', 'Lopez', 'Diaz', 'maria.lopez@example.com', NOW(), 1);

INSERT IGNORE INTO usuario_estudiante (idEstudiante, contraseña, fecha_creacion, es_activo) VALUES
('EST-001', 'hashed_pwd_123', NOW(), 1),
('EST-002', 'hashed_pwd_456', NOW(), 1);

INSERT IGNORE INTO cursos (codigo_curso, nombre_curso, descripcion, duracion_horas, nivel_dificultad, categoria, es_activo) VALUES
('CUR-001', 'Arquitectura de Software', 'Aprende Clean Architecture', 40.00, 'Avanzado', 'Tecnología', 1),
('CUR-002', 'Docker y Kubernetes', 'Contenedores desde cero', 20.00, 'Intermedio', 'Tecnología', 1),
('CUR-003', 'Machine Learning', 'Introducción a la IA', 60.00, 'Avanzado', 'Ciencia de Datos', 1);

USE `adaptive_engine`;
INSERT IGNORE INTO perfiles_estudiante (idEstudiante, estilo_aprendizaje_id, ritmo_aprendizaje_id, nivel_atencion, fecha_actualizacion) VALUES
('EST-001', 1, 1, 0.85, NOW()),
('EST-002', 2, 2, 0.90, NOW());

USE `competency_mapping`;
-- Asumimos que los id de competencia coinciden con evaluaciones
INSERT IGNORE INTO mapas_competencias_estudiantes (idEstudiante, idCompetencia, nivel_dominio, estado_dominio_id, confianza, fecha_actualizacion) VALUES
('EST-001', 1, 0.00, 1, 0.00, NOW()),
('EST-002', 1, 0.00, 1, 0.00, NOW());
