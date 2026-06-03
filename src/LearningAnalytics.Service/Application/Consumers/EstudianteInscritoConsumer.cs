using BuildingBlocks.IntegrationEvents;
using LearningAnalytics.Service.Application.Commands;
using MassTransit;
using MediatR;

namespace LearningAnalytics.Service.Application.Consumers;

public class EstudianteInscritoConsumer : IConsumer<EstudianteInscritoEvent>
{
    private readonly IMediator _mediator;

    public EstudianteInscritoConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<EstudianteInscritoEvent> context)
    {
        var evento = context.Message;
        
        // Registrar este evento como telemetría en LearningAnalytics
        var command = new RegistrarEventoAprendizajeCommand
        {
            EstudianteId = evento.EstudianteId,
            ContenidoId = evento.CursoId, // Asumiendo que el curso actúa como un contenido para esta métrica
            TipoEventoId = 1, // ID simulado para INSCRIPCION
            MetadatosJson = "{\"origen\": \"SistemaEventos\"}"
        };

        await _mediator.Send(command);
    }
}
