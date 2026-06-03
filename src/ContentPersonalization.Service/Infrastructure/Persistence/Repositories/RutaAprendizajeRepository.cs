using ContentPersonalization.Service.Domain.Entities;
using ContentPersonalization.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContentPersonalization.Service.Infrastructure.Persistence.Repositories;

public class RutaAprendizajeRepository : IRutaAprendizajeRepository
{
    private readonly ContentPersonalizationContext _context;

    public RutaAprendizajeRepository(ContentPersonalizationContext context)
    {
        _context = context;
    }

    public async Task<RutaAprendizaje?> ObtenerPorEstudianteIdAsync(string estudianteId, CancellationToken cancellationToken = default)
    {
        return await _context.RutasAprendizaje
            .Include(r => r.EstadoRuta)
            .Include(r => r.ModelosRuta)
            .FirstOrDefaultAsync(r => r.EstudianteId == estudianteId && r.EsActivo, cancellationToken);
    }

    public async Task AgregarAsync(RutaAprendizaje ruta, CancellationToken cancellationToken = default)
    {
        await _context.RutasAprendizaje.AddAsync(ruta, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task ActualizarAsync(RutaAprendizaje ruta, CancellationToken cancellationToken = default)
    {
        _context.RutasAprendizaje.Update(ruta);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
