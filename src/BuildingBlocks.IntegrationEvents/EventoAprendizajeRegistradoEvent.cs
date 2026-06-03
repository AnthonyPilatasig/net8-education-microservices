namespace BuildingBlocks.IntegrationEvents;

public record EventoAprendizajeRegistradoEvent(
    string EstudianteId,
    string TipoEvento,
    string ElementoId,
    DateTime FechaRegistro
);
