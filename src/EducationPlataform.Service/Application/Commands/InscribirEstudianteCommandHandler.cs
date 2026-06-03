using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Domain.Repositories;
using MediatR;
using MassTransit;
using BuildingBlocks.IntegrationEvents;

namespace EducationPlataform.Service.Application.Commands;

public class InscribirEstudianteCommandHandler : IRequestHandler<InscribirEstudianteCommand, bool>
{
    private readonly IInscripcionRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;

    public InscribirEstudianteCommandHandler(IInscripcionRepository repository, IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> Handle(InscribirEstudianteCommand request, CancellationToken cancellationToken)
    {
        var existeInscripcion = await _repository.ObtenerPorEstudianteYCursoAsync(request.EstudianteId, request.CursoId, cancellationToken);
        
        if (existeInscripcion != null)
        {
            throw new Exception("El estudiante ya se encuentra inscrito en este curso.");
        }

        var inscripcion = new Inscripcion(request.EstudianteId, request.CursoId);
        
        await _repository.AgregarAsync(inscripcion, cancellationToken);
        
        // Publicar el evento global
        var evento = new EstudianteInscritoEvent(
            inscripcion.EstudianteId,
            inscripcion.CursoId,
            DateTime.UtcNow
        );
        
        await _publishEndpoint.Publish(evento, cancellationToken);
        
        return true;
    }
}
