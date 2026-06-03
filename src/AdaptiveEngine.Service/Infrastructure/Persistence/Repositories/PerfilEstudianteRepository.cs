using AdaptiveEngine.Service.Domain.Entities;
using AdaptiveEngine.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdaptiveEngine.Service.Infrastructure.Persistence.Repositories;

public class PerfilEstudianteRepository : IPerfilEstudianteRepository
{
    private readonly AdaptiveEngineContext _context;

    public PerfilEstudianteRepository(AdaptiveEngineContext context)
    {
        _context = context;
    }

    public async Task<PerfilEstudiante?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.PerfilesEstudiantes
            .Include(x => x.EstiloAprendizaje)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<PerfilEstudiante?> ObtenerPorEstudianteIdAsync(string estudianteId, CancellationToken cancellationToken = default)
    {
        return await _context.PerfilesEstudiantes
            .Include(x => x.EstiloAprendizaje)
            .FirstOrDefaultAsync(x => x.EstudianteId == estudianteId, cancellationToken);
    }

    public async Task AgregarAsync(PerfilEstudiante perfil, CancellationToken cancellationToken = default)
    {
        await _context.PerfilesEstudiantes.AddAsync(perfil, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task ActualizarAsync(PerfilEstudiante perfil, CancellationToken cancellationToken = default)
    {
        _context.PerfilesEstudiantes.Update(perfil);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
