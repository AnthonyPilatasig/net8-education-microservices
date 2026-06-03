namespace CompetencyMapping.Service.Domain.Entities;

public class EstadoDominio
{
    public int Id { get; private set; }
    public string NombreEstado { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    protected EstadoDominio() { }

    public EstadoDominio(string nombreEstado, string descripcion)
    {
        NombreEstado = nombreEstado;
        Descripcion = descripcion;
        EsActivo = true;
    }
}
