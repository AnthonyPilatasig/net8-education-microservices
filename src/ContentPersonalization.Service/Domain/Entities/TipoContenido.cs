namespace ContentPersonalization.Service.Domain.Entities;

public class TipoContenido
{
    public int Id { get; private set; }
    public string NombreTipo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    protected TipoContenido() { }

    public TipoContenido(string nombreTipo, string descripcion)
    {
        NombreTipo = nombreTipo;
        Descripcion = descripcion;
        EsActivo = true;
    }
}
