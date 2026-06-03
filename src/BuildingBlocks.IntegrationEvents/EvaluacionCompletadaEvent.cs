namespace BuildingBlocks.IntegrationEvents;

public record EvaluacionCompletadaEvent(
    string EstudianteId,
    int EvaluacionId,
    decimal PuntajeObtenido,
    decimal PuntajeMaximo,
    DateTime FechaCompletacion
);
