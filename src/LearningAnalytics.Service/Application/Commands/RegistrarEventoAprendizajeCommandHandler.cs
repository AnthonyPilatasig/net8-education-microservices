using LearningAnalytics.Service.Domain.Entities;
using LearningAnalytics.Service.Domain.Repositories;
using MediatR;

namespace LearningAnalytics.Service.Application.Commands;

public class RegistrarEventoAprendizajeCommandHandler : IRequestHandler<RegistrarEventoAprendizajeCommand, bool>
{
    private readonly IEventoAprendizajeRepository _repository;

    public RegistrarEventoAprendizajeCommandHandler(IEventoAprendizajeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(RegistrarEventoAprendizajeCommand request, CancellationToken cancellationToken)
    {
        var evento = new EventoAprendizaje(
            request.EstudianteId,
            request.ContenidoId,
            request.TipoEventoId,
            request.MetadatosJson
        );

        await _repository.AgregarAsync(evento, cancellationToken);
        
        return true;
    }
}
