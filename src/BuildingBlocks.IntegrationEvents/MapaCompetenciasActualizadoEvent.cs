namespace BuildingBlocks.IntegrationEvents;

public record MapaCompetenciasActualizadoEvent(
    string EstudianteId,
    int CompetenciaId,
    decimal NuevoNivelDominio,
    DateTime FechaActualizacion
);
