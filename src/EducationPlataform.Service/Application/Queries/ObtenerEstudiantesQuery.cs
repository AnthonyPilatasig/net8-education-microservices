using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EducationPlataform.Service.Application.Queries;

public record ObtenerEstudiantesQuery : IRequest<List<Estudiante>>;

public class ObtenerEstudiantesQueryHandler : IRequestHandler<ObtenerEstudiantesQuery, List<Estudiante>>
{
    private readonly EducationPlatformContext _context;

    public ObtenerEstudiantesQueryHandler(EducationPlatformContext context)
    {
        _context = context;
    }

    public async Task<List<Estudiante>> Handle(ObtenerEstudiantesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Estudiantes
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
