using CompetencyMapping.Service.Domain.Entities;
using CompetencyMapping.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompetencyMapping.Service.Infrastructure.Persistence.Repositories;

public class MapaCompetenciaEstudianteRepository : IMapaCompetenciaEstudianteRepository
{
    private readonly CompetencyMappingContext _context;

    public MapaCompetenciaEstudianteRepository(CompetencyMappingContext context)
    {
        _context = context;
    }

    public async Task<MapaCompetenciaEstudiante?> ObtenerPorEstudianteYCompetenciaAsync(string estudianteId, int competenciaId, CancellationToken cancellationToken = default)
    {
        return await _context.MapasCompetenciasEstudiante
            .Include(m => m.EstadoDominio)
            .FirstOrDefaultAsync(m => m.EstudianteId == estudianteId && m.CompetenciaId == competenciaId, cancellationToken);
    }

    public async Task AgregarAsync(MapaCompetenciaEstudiante mapa, CancellationToken cancellationToken = default)
    {
        await _context.MapasCompetenciasEstudiante.AddAsync(mapa, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task ActualizarAsync(MapaCompetenciaEstudiante mapa, CancellationToken cancellationToken = default)
    {
        _context.MapasCompetenciasEstudiante.Update(mapa);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
