using AdaptiveEngine.Service.Domain.Exceptions;

namespace AdaptiveEngine.Service.Domain.Entities;

public class PerfilEstudiante
{
    public int Id { get; private set; }
    public string EstudianteId { get; private set; } = string.Empty;
    public int EstiloAprendizajeId { get; private set; }
    public decimal NivelActual { get; private set; }
    public decimal VelocidadAprendizaje { get; private set; }
    public DateTime FechaActualizacion { get; private set; }
    public bool EsActivo { get; private set; }

    // Navigation property
    public virtual EstiloAprendizaje? EstiloAprendizaje { get; private set; }

    protected PerfilEstudiante() { }

    public PerfilEstudiante(string estudianteId, int estiloAprendizajeId)
    {
        if (string.IsNullOrWhiteSpace(estudianteId))
            throw new DomainException("El ID del estudiante no puede estar vacío.");

        EstudianteId = estudianteId;
        EstiloAprendizajeId = estiloAprendizajeId;
        NivelActual = 1.0m;
        VelocidadAprendizaje = 1.0m;
        FechaActualizacion = DateTime.UtcNow;
        EsActivo = true;
    }

    public void ActualizarNivelAprendizaje(decimal puntuacionRendimiento)
    {
        if (puntuacionRendimiento < 0 || puntuacionRendimiento > 100)
            throw new DomainException("La puntuación debe estar entre 0 y 100.");

        if (puntuacionRendimiento > 85)
            NivelActual += 0.5m;
        else if (puntuacionRendimiento < 50)
            NivelActual = Math.Max(1.0m, NivelActual - 0.2m);

        ActualizarFechaModificacion();
    }

    public void ActualizarVelocidad(decimal nuevaVelocidad)
    {
        if (nuevaVelocidad <= 0)
            throw new DomainException("La velocidad de aprendizaje debe ser mayor a cero.");

        VelocidadAprendizaje = nuevaVelocidad;
        ActualizarFechaModificacion();
    }

    public void Desactivar()
    {
        EsActivo = false;
        ActualizarFechaModificacion();
    }

    private void ActualizarFechaModificacion()
    {
        FechaActualizacion = DateTime.UtcNow;
    }
}
