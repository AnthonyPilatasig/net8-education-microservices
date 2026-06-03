using CompetencyMapping.Service.Domain.Exceptions;

namespace CompetencyMapping.Service.Domain.Entities;

public class BrechaAprendizaje
{
    public int Id { get; private set; }
    public string EstudianteId { get; private set; } = string.Empty;
    public int CompetenciaId { get; private set; }
    public decimal NivelActual { get; private set; }
    public decimal NivelRequerido { get; private set; }
    public int NivelPrioridadId { get; private set; }
    public DateTime FechaDeteccion { get; private set; }
    public bool EsActiva { get; private set; }

    public virtual NivelPrioridad? NivelPrioridad { get; private set; }

    protected BrechaAprendizaje() { }

    public BrechaAprendizaje(string estudianteId, int competenciaId, decimal nivelActual, decimal nivelRequerido, int nivelPrioridadId)
    {
        if (string.IsNullOrWhiteSpace(estudianteId))
            throw new DomainException("El ID del estudiante no puede estar vacío.");

        if (nivelActual >= nivelRequerido)
            throw new DomainException("No existe brecha si el nivel actual es mayor o igual al requerido.");

        EstudianteId = estudianteId;
        CompetenciaId = competenciaId;
        NivelActual = nivelActual;
        NivelRequerido = nivelRequerido;
        NivelPrioridadId = nivelPrioridadId;
        FechaDeteccion = DateTime.UtcNow;
        EsActiva = true;
    }

    public void ResolverBrecha()
    {
        EsActiva = false;
    }
}
