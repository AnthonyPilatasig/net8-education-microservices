using CompetencyMapping.Service.Domain.Entities;

namespace CompetencyMapping.Service.Domain.Repositories;

public interface IMapaCompetenciaEstudianteRepository
{
    Task<MapaCompetenciaEstudiante?> ObtenerPorEstudianteYCompetenciaAsync(string estudianteId, int competenciaId, CancellationToken cancellationToken = default);
    Task AgregarAsync(MapaCompetenciaEstudiante mapa, CancellationToken cancellationToken = default);
    Task ActualizarAsync(MapaCompetenciaEstudiante mapa, CancellationToken cancellationToken = default);
}
