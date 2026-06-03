namespace Assessment.Service.Domain.Entities;

public class TipoEvaluacion
{
    public int Id { get; private set; }
    public string NombreTipo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    private readonly List<Evaluacion> _evaluaciones = new();
    public virtual IReadOnlyCollection<Evaluacion> Evaluaciones => _evaluaciones.AsReadOnly();

    protected TipoEvaluacion() { }

    public TipoEvaluacion(string nombreTipo, string descripcion)
    {
        NombreTipo = nombreTipo;
        Descripcion = descripcion;
        EsActivo = true;
    }
}
