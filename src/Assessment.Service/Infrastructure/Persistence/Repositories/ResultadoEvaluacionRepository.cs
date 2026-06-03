using Assessment.Service.Domain.Entities;
using Assessment.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Service.Infrastructure.Persistence.Repositories;

public class ResultadoEvaluacionRepository : IResultadoEvaluacionRepository
{
    private readonly AssessmentContext _context;

    public ResultadoEvaluacionRepository(AssessmentContext context)
    {
        _context = context;
    }

    public async Task AgregarAsync(ResultadoEvaluacion resultado, CancellationToken cancellationToken = default)
    {
        await _context.ResultadosEvaluacion.AddAsync(resultado, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<ResultadoEvaluacion>> ObtenerPorEstudianteIdAsync(string estudianteId, CancellationToken cancellationToken = default)
    {
        return await _context.ResultadosEvaluacion
            .Include(r => r.Evaluacion)
            .Where(r => r.EstudianteId == estudianteId)
            .OrderByDescending(r => r.FechaCompletacion)
            .ToListAsync(cancellationToken);
    }
}
