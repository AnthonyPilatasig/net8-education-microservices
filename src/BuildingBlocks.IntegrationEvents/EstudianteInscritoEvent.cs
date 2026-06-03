namespace BuildingBlocks.IntegrationEvents;

public record EstudianteInscritoEvent(
    string EstudianteId,
    int CursoId,
    DateTime FechaInscripcion
);
