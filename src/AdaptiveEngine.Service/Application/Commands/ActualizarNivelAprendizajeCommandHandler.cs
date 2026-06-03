using AdaptiveEngine.Service.Domain.Exceptions;
using AdaptiveEngine.Service.Domain.Repositories;
using MediatR;

namespace AdaptiveEngine.Service.Application.Commands;

public class ActualizarNivelAprendizajeCommandHandler : IRequestHandler<ActualizarNivelAprendizajeCommand, bool>
{
    private readonly IPerfilEstudianteRepository _repository;

    public ActualizarNivelAprendizajeCommandHandler(IPerfilEstudianteRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ActualizarNivelAprendizajeCommand request, CancellationToken cancellationToken)
    {
        var perfil = await _repository.ObtenerPorEstudianteIdAsync(request.EstudianteId, cancellationToken);
        
        if (perfil == null)
            throw new DomainException($"El perfil del estudiante con ID {request.EstudianteId} no fue encontrado.");

        perfil.ActualizarNivelAprendizaje(request.PuntuacionRendimiento);
        
        await _repository.ActualizarAsync(perfil, cancellationToken);
        
        return true;
    }
}
