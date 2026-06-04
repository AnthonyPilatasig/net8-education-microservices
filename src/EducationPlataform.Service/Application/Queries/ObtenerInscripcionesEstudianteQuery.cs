using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EducationPlataform.Service.Application.Queries;

public record ObtenerInscripcionesEstudianteQuery(string EstudianteId) : IRequest<List<Inscripcion>>;

public class ObtenerInscripcionesEstudianteQueryHandler : IRequestHandler<ObtenerInscripcionesEstudianteQuery, List<Inscripcion>>
{
    private readonly EducationPlatformContext _context;

    public ObtenerInscripcionesEstudianteQueryHandler(EducationPlatformContext context)
    {
        _context = context;
    }

    public async Task<List<Inscripcion>> Handle(ObtenerInscripcionesEstudianteQuery request, CancellationToken cancellationToken)
    {
        return await _context.Inscripciones
            .Include(i => i.Curso)
            .AsNoTracking()
            .Where(i => i.EstudianteId == request.EstudianteId)
            .ToListAsync(cancellationToken);
    }
}
