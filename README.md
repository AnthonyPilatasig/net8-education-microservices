# 🎓 Plataforma Educativa Inteligente (Arquitectura de Microservicios)

Un ecosistema avanzado de microservicios desarrollado en **.NET 8**, diseñado para revolucionar el aprendizaje online mediante evaluación adaptativa, mapeo de competencias y personalización de contenido en tiempo real.

---

## 🏗️ Arquitectura del Sistema

El proyecto ha sido refactorizado para adoptar un enfoque de **Clean Architecture** (Arquitectura Limpia) en todos sus microservicios. Esta decisión estratégica busca maximizar la mantenibilidad, escalabilidad y testabilidad del sistema.

### ¿Por qué Clean Architecture?
*   **Independencia de Frameworks**: La lógica core de nuestro negocio (el Dominio) no depende de Entity Framework, ASP.NET o cualquier otra librería externa.
*   **Independencia de la Base de Datos**: Las bases de datos MySQL son un simple mecanismo de persistencia. El modelo de datos de la DB no dicta las reglas de nuestro código.
*   **Testabilidad**: La lógica de negocio está completamente aislada, lo que permite crear pruebas unitarias sin mockear conexiones a DBs pesadas o frameworks complejos.

### Patrones de Diseño Empleados
Para asegurar un código de grado Senior, el ecosistema se apoya fuertemente en:
1.  **DDD (Domain-Driven Design)**: Se han creado **Agregados Ricos** y entidades que protegen su propio estado. En lugar de modelos anémicos con `get` y `set` públicos, las entidades validan sus propias reglas mediante constructores y métodos con intención (ej: `RecalcularCompromiso()` en `SesionAprendizaje`). Se usa una nomenclatura estricta en español (Lenguaje Ubicuo).
2.  **CQRS (Command Query Responsibility Segregation)**: A través de la librería **MediatR**, hemos separado las operaciones que modifican estado (Commands) de las que lo leen (Queries). Esto permite que cada operación escale independientemente y reduce drásticamente el acoplamiento en la capa API.
3.  **Inyección de Dependencias (SOLID - D)**: Todos los componentes dependen de abstracciones (interfaces como `IRepository`) en lugar de implementaciones concretas, garantizando el Principio de Inversión de Dependencias.
4.  **Minimal APIs**: Reemplazamos los pesados Controllers MVC por Minimal APIs en ASP.NET Core 8, mejorando el rendimiento y reduciendo el "boilerplate".

---

## 🧩 Ecosistema de Microservicios

El sistema está compuesto por 6 microservicios fundamentales, cada uno enfocado en un Dominio específico (Bounded Context):

### 1. EducationPlatform.Service 🏫
*El Core Administrativo.* Administra la identidad de los estudiantes, el catálogo de cursos disponibles y gestiona el ciclo de vida de las inscripciones.

### 2. AdaptiveEngine.Service ⚙️
*El Cerebro Adaptativo.* Analiza el desempeño en tiempo real y ajusta la dificultad de las evaluaciones dinámicamente según las capacidades demostradas por el estudiante.

### 3. Assessment.Service 📝
*Gestor de Evaluaciones.* Controla la creación de exámenes, bancos de preguntas complejas y registra los resultados detallados de cada intento del estudiante.

### 4. CompetencyMapping.Service 🎯
*Mapeador de Talentos.* Transforma los resultados de las evaluaciones en niveles de dominio. Identifica "Brechas de Aprendizaje" comparando el nivel actual del estudiante contra el nivel requerido de una competencia específica.

### 5. ContentPersonalization.Service 📚
*El Tutor Personal.* Consumiendo las brechas detectadas, este servicio ensambla y entrega "Rutas de Aprendizaje" únicas, recomendando el contenido educativo exacto que el estudiante necesita para mejorar.

### 6. LearningAnalytics.Service 📊
*El Observador Silencioso.* Recopila eventos de telemetría (pausas de videos, clicks, tiempo en pantalla) para calcular "Métricas de Compromiso" y predecir posibles abandonos antes de que sucedan.

---

## 🚀 Hoja de Ruta (Roadmap) y Fases de Desarrollo

Para llevar este proyecto a una etapa de "Producción Grado Enterprise", hemos dividido el desarrollo en las siguientes fases:

### ✅ Fase 1: Estandarización Arquitectónica (COMPLETADA)
*   Refactorización total a Clean Architecture (Domain, Application, Infrastructure, API).
*   Implementación de DDD (Domain-Driven Design) con Agregados ricos.
*   Implementación de CQRS con MediatR.
*   Limpieza de EF Core Power Tools y migración a configuración por Fluent API.

### ⏳ Fase 2: Comunicación Asíncrona (EN PROGRESO)
*Los microservicios no deben llamarse por HTTP de forma síncrona si no es necesario.*
*   Implementación de un **Message Broker (RabbitMQ)**.
*   Uso de **MassTransit** para publicar y suscribirse a Eventos de Integración (ej: `EstudianteInscritoEvent`, `EvaluacionCompletadaEvent`).
*   Esto logrará un desacoplamiento definitivo y resiliencia ante caídas de red.

### 📅 Fase 3: Gateway y Seguridad
*   Implementación de **Ocelot API Gateway** o **YARP** como único punto de entrada para los clientes web/móviles.
*   Autenticación unificada mediante **JWT (JSON Web Tokens)** e Identity Server / Keycloak.

### 📅 Fase 4: Observabilidad y Despliegue
*   Implementación de logs centralizados (Serilog + ELK Stack o Seq).
*   Trazabilidad distribuida con OpenTelemetry.
*   Dockerización de todos los servicios (`docker-compose` y `Dockerfiles`).

---

## 🛠️ Tecnologías Principales

*   **.NET 8** (C# 12)
*   **ASP.NET Core Minimal APIs**
*   **Entity Framework Core 8** (MySQL / Pomelo)
*   **MediatR** (CQRS)
*   **Swagger / OpenAPI**
