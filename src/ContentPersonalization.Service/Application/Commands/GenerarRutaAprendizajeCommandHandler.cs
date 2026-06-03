using ContentPersonalization.Service.Domain.Entities;
using ContentPersonalization.Service.Domain.Repositories;
using MediatR;

namespace ContentPersonalization.Service.Application.Commands;

public class GenerarRutaAprendizajeCommandHandler : IRequestHandler<GenerarRutaAprendizajeCommand, bool>
{
    private readonly IRutaAprendizajeRepository _repository;

    public GenerarRutaAprendizajeCommandHandler(IRutaAprendizajeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(GenerarRutaAprendizajeCommand request, CancellationToken cancellationToken)
    {
        var ruta = new RutaAprendizaje(
            request.EstudianteId,
            request.NombreRuta,
            request.EstadoRutaId
        );

        int orden = 1;
        foreach (var contenidoId in request.ContenidosIds)
        {
            ruta.AgregarModulo(new ModeloRuta(ruta.Id, contenidoId, orden));
            orden++;
        }

        await _repository.AgregarAsync(ruta, cancellationToken);
        
        return true;
    }
}
