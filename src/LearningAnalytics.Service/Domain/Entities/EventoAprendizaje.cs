using LearningAnalytics.Service.Domain.Exceptions;

namespace LearningAnalytics.Service.Domain.Entities;

public class EventoAprendizaje
{
    public int Id { get; private set; }
    public string EstudianteId { get; private set; } = string.Empty;
    public int ContenidoId { get; private set; }
    public int TipoEventoId { get; private set; }
    public DateTime FechaEvento { get; private set; }
    public string MetadatosJson { get; private set; } = "{}";
    public bool EsActivo { get; private set; }

    public virtual TipoEvento? TipoEvento { get; private set; }

    protected EventoAprendizaje() { }

    public EventoAprendizaje(string estudianteId, int contenidoId, int tipoEventoId, string metadatosJson = "{}")
    {
        if (string.IsNullOrWhiteSpace(estudianteId))
            throw new DomainException("El ID del estudiante no puede estar vacío.");

        EstudianteId = estudianteId;
        ContenidoId = contenidoId;
        TipoEventoId = tipoEventoId;
        FechaEvento = DateTime.UtcNow;
        MetadatosJson = metadatosJson;
        EsActivo = true;
    }
}
