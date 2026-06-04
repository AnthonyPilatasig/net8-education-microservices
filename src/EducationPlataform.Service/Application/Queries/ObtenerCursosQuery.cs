using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EducationPlataform.Service.Application.Queries;

public record ObtenerCursosQuery : IRequest<List<Curso>>;

public class ObtenerCursosQueryHandler : IRequestHandler<ObtenerCursosQuery, List<Curso>>
{
    private readonly EducationPlatformContext _context;

    public ObtenerCursosQueryHandler(EducationPlatformContext context)
    {
        _context = context;
    }

    public async Task<List<Curso>> Handle(ObtenerCursosQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cursos
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
