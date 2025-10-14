-- Crear bases de datos para cada microservicio
CREATE DATABASE IF NOT EXISTS learning_analytics;
CREATE DATABASE IF NOT EXISTS adaptive_engine;
CREATE DATABASE IF NOT EXISTS content_personalization;
CREATE DATABASE IF NOT EXISTS assessment;
CREATE DATABASE IF NOT EXISTS competency_mapping;

-- Usuario para aplicacion (opcional)
CREATE USER IF NOT EXISTS 'education_user'@'%' IDENTIFIED BY 'education123';
GRANT ALL PRIVILEGES ON learning_analytics.* TO 'education_user'@'%';
GRANT ALL PRIVILEGES ON adaptive_engine.* TO 'education_user'@'%';
GRANT ALL PRIVILEGES ON content_personalization.* TO 'education_user'@'%';
GRANT ALL PRIVILEGES ON assessment.* TO 'education_user'@'%';
GRANT ALL PRIVILEGES ON competency_mapping.* TO 'education_user'@'%';
FLUSH PRIVILEGES;