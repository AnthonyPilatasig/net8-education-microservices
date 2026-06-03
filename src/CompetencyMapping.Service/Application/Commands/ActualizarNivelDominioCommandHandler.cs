using CompetencyMapping.Service.Domain.Entities;
using CompetencyMapping.Service.Domain.Exceptions;
using CompetencyMapping.Service.Domain.Repositories;
using MediatR;
using MassTransit;
using BuildingBlocks.IntegrationEvents;

namespace CompetencyMapping.Service.Application.Commands;

public class ActualizarNivelDominioCommandHandler : IRequestHandler<ActualizarNivelDominioCommand, bool>
{
    private readonly IMapaCompetenciaEstudianteRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;

    public ActualizarNivelDominioCommandHandler(IMapaCompetenciaEstudianteRepository repository, IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> Handle(ActualizarNivelDominioCommand request, CancellationToken cancellationToken)
    {
        var mapa = await _repository.ObtenerPorEstudianteYCompetenciaAsync(request.EstudianteId, request.CompetenciaId, cancellationToken);
        
        if (mapa == null)
        {
            // Si no existe, lo creamos
            mapa = new MapaCompetenciaEstudiante(
                request.EstudianteId,
                request.CompetenciaId,
                request.NivelDominio,
                request.EstadoDominioId,
                request.Confianza
            );
            await _repository.AgregarAsync(mapa, cancellationToken);
        }
        else
        {
            mapa.ActualizarNivelDominio(request.NivelDominio, request.EstadoDominioId, request.Confianza);
            await _repository.ActualizarAsync(mapa, cancellationToken);
        }
        
        // Publicar el evento
        var evento = new MapaCompetenciasActualizadoEvent(
            mapa.EstudianteId,
            mapa.CompetenciaId,
            mapa.NivelDominio,
            DateTime.UtcNow
        );
        
        await _publishEndpoint.Publish(evento, cancellationToken);
        
        return true;
    }
}
