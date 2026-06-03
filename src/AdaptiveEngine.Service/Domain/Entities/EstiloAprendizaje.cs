namespace AdaptiveEngine.Service.Domain.Entities;

public class EstiloAprendizaje
{
    public int Id { get; private set; }
    public string NombreEstilo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    private readonly List<PerfilEstudiante> _perfilesEstudiantes = new();
    public virtual IReadOnlyCollection<PerfilEstudiante> PerfilesEstudiantes => _perfilesEstudiantes.AsReadOnly();

    protected EstiloAprendizaje() { }

    public EstiloAprendizaje(string nombreEstilo, string descripcion)
    {
        NombreEstilo = nombreEstilo;
        Descripcion = descripcion;
        EsActivo = true;
    }
}
