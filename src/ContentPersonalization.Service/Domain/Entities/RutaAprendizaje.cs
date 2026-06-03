using ContentPersonalization.Service.Domain.Exceptions;

namespace ContentPersonalization.Service.Domain.Entities;

public class RutaAprendizaje
{
    public int Id { get; private set; }
    public string EstudianteId { get; private set; } = string.Empty;
    public string NombreRuta { get; private set; } = string.Empty;
    public int EstadoRutaId { get; private set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime FechaActualizacion { get; private set; }
    public bool EsActivo { get; private set; }

    public virtual EstadoRuta? EstadoRuta { get; private set; }

    private readonly List<ModeloRuta> _modelosRuta = new();
    public virtual IReadOnlyCollection<ModeloRuta> ModelosRuta => _modelosRuta.AsReadOnly();

    protected RutaAprendizaje() { }

    public RutaAprendizaje(string estudianteId, string nombreRuta, int estadoRutaId)
    {
        if (string.IsNullOrWhiteSpace(estudianteId))
            throw new DomainException("El ID del estudiante no puede estar vacío.");

        EstudianteId = estudianteId;
        NombreRuta = nombreRuta;
        EstadoRutaId = estadoRutaId;
        FechaCreacion = DateTime.UtcNow;
        FechaActualizacion = DateTime.UtcNow;
        EsActivo = true;
    }

    public void AgregarModulo(ModeloRuta modulo)
    {
        _modelosRuta.Add(modulo);
        FechaActualizacion = DateTime.UtcNow;
    }
}
