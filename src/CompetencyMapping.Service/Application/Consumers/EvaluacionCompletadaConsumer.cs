using BuildingBlocks.IntegrationEvents;
using CompetencyMapping.Service.Application.Commands;
using MassTransit;
using MediatR;

namespace CompetencyMapping.Service.Application.Consumers;

public class EvaluacionCompletadaConsumer : IConsumer<EvaluacionCompletadaEvent>
{
    private readonly IMediator _mediator;

    public EvaluacionCompletadaConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<EvaluacionCompletadaEvent> context)
    {
        var evento = context.Message;
        
        // Mapear el evento al Command interno del microservicio
        var command = new ActualizarNivelDominioCommand
        {
            EstudianteId = evento.EstudianteId,
            CompetenciaId = evento.EvaluacionId, // Asumiendo relación 1:1 por simplicidad en este MVP
            NivelDominio = evento.PuntajeObtenido,
            EstadoDominioId = 1,
            Confianza = 0.9m
        };

        // Procesar la actualización a través del Handler interno que ya tiene la lógica de negocio rica
        await _mediator.Send(command);
    }
}
