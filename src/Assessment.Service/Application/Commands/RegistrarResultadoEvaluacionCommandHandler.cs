using Assessment.Service.Domain.Entities;
using Assessment.Service.Domain.Repositories;
using MediatR;
using MassTransit;
using BuildingBlocks.IntegrationEvents;

namespace Assessment.Service.Application.Commands;

public class RegistrarResultadoEvaluacionCommandHandler : IRequestHandler<RegistrarResultadoEvaluacionCommand, bool>
{
    private readonly IResultadoEvaluacionRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;

    public RegistrarResultadoEvaluacionCommandHandler(IResultadoEvaluacionRepository repository, IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> Handle(RegistrarResultadoEvaluacionCommand request, CancellationToken cancellationToken)
    {
        var resultado = new ResultadoEvaluacion(
            request.EstudianteId,
            request.EvaluacionId,
            request.PuntajeObtenido,
            request.PuntajeMaximo,
            request.TiempoEmpleadoMinutos
        );

        await _repository.AgregarAsync(resultado, cancellationToken);
        
        // Publicar evento de integración
        var evento = new EvaluacionCompletadaEvent(
            resultado.EstudianteId,
            resultado.EvaluacionId,
            resultado.PuntajeObtenido,
            resultado.PuntajeMaximo,
            DateTime.UtcNow
        );
        
        await _publishEndpoint.Publish(evento, cancellationToken);

        return true;
    }
}
