namespace Assessment.Service.Domain.Entities;

public class TipoPregunta
{
    public int Id { get; private set; }
    public string NombreTipo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    private readonly List<Pregunta> _preguntas = new();
    public virtual IReadOnlyCollection<Pregunta> Preguntas => _preguntas.AsReadOnly();

    protected TipoPregunta() { }

    public TipoPregunta(string nombreTipo, string descripcion)
    {
        NombreTipo = nombreTipo;
        Descripcion = descripcion;
        EsActivo = true;
    }
}
