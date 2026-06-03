namespace CompetencyMapping.Service.Domain.Entities;

public class CategoriaCompetencia
{
    public int Id { get; private set; }
    public string NombreCategoria { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    protected CategoriaCompetencia() { }

    public CategoriaCompetencia(string nombreCategoria, string descripcion)
    {
        NombreCategoria = nombreCategoria;
        Descripcion = descripcion;
        EsActivo = true;
    }
}
