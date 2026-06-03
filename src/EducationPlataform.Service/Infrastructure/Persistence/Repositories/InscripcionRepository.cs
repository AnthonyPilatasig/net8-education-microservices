using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EducationPlataform.Service.Infrastructure.Persistence.Repositories;

public class InscripcionRepository : IInscripcionRepository
{
    private readonly EducationPlatformContext _context;

    public InscripcionRepository(EducationPlatformContext context)
    {
        _context = context;
    }

    public async Task<Inscripcion?> ObtenerPorEstudianteYCursoAsync(string estudianteId, int cursoId, CancellationToken cancellationToken = default)
    {
        return await _context.Inscripciones
            .FirstOrDefaultAsync(i => i.EstudianteId == estudianteId && i.CursoId == cursoId, cancellationToken);
    }

    public async Task AgregarAsync(Inscripcion inscripcion, CancellationToken cancellationToken = default)
    {
        await _context.Inscripciones.AddAsync(inscripcion, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task ActualizarAsync(Inscripcion inscripcion, CancellationToken cancellationToken = default)
    {
        _context.Inscripciones.Update(inscripcion);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
