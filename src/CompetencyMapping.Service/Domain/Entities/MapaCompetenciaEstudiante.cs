using CompetencyMapping.Service.Domain.Exceptions;

namespace CompetencyMapping.Service.Domain.Entities;

public class MapaCompetenciaEstudiante
{
    public int Id { get; private set; }
    public string EstudianteId { get; private set; } = string.Empty;
    public int CompetenciaId { get; private set; }
    public decimal NivelDominio { get; private set; }
    public int EstadoDominioId { get; private set; }
    public decimal Confianza { get; private set; }
    public DateTime FechaEvaluacion { get; private set; }
    public bool EsActivo { get; private set; }

    public virtual EstadoDominio? EstadoDominio { get; private set; }

    protected MapaCompetenciaEstudiante() { }

    public MapaCompetenciaEstudiante(string estudianteId, int competenciaId, decimal nivelDominio, int estadoDominioId, decimal confianza)
    {
        if (string.IsNullOrWhiteSpace(estudianteId))
            throw new DomainException("El ID del estudiante no puede estar vacío.");

        if (nivelDominio < 0 || nivelDominio > 100)
            throw new DomainException("El nivel de dominio debe estar entre 0 y 100.");

        EstudianteId = estudianteId;
        CompetenciaId = competenciaId;
        NivelDominio = nivelDominio;
        EstadoDominioId = estadoDominioId;
        Confianza = confianza;
        FechaEvaluacion = DateTime.UtcNow;
        EsActivo = true;
    }

    public void ActualizarNivelDominio(decimal nuevoNivel, int nuevoEstadoId, decimal nuevaConfianza)
    {
        if (nuevoNivel < 0 || nuevoNivel > 100)
            throw new DomainException("El nivel de dominio debe estar entre 0 y 100.");

        NivelDominio = nuevoNivel;
        EstadoDominioId = nuevoEstadoId;
        Confianza = nuevaConfianza;
        FechaEvaluacion = DateTime.UtcNow;
    }
}
