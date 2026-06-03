using BuildingBlocks.IntegrationEvents;
using ContentPersonalization.Service.Application.Commands;
using MassTransit;
using MediatR;

namespace ContentPersonalization.Service.Application.Consumers;

public class MapaCompetenciasActualizadoConsumer : IConsumer<MapaCompetenciasActualizadoEvent>
{
    private readonly IMediator _mediator;

    public MapaCompetenciasActualizadoConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<MapaCompetenciasActualizadoEvent> context)
    {
        var evento = context.Message;
        
        // Simular que buscamos contenidos para cubrir esa competencia
        // En un MVP real esto iría a buscar a la DB según el evento.CompetenciaId
        var command = new GenerarRutaAprendizajeCommand
        {
            EstudianteId = evento.EstudianteId,
            NombreRuta = $"Ruta de Refuerzo Competencia {evento.CompetenciaId}",
            EstadoRutaId = 1, // ACTIVO
            ContenidosIds = new List<int> { 1, 2, 3 } // Ids simulados de contenido
        };

        // Enviar a MediatR para que cree la Ruta de Aprendizaje de manera aislada
        await _mediator.Send(command);
    }
}
