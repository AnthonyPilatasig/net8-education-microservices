using Assessment.Service.Domain.Entities;

namespace Assessment.Service.Domain.Repositories;

public interface IResultadoEvaluacionRepository
{
    Task AgregarAsync(ResultadoEvaluacion resultado, CancellationToken cancellationToken = default);
    Task<IEnumerable<ResultadoEvaluacion>> ObtenerPorEstudianteIdAsync(string estudianteId, CancellationToken cancellationToken = default);
}
