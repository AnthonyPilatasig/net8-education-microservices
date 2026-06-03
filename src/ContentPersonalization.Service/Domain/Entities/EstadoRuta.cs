namespace ContentPersonalization.Service.Domain.Entities;

public class EstadoRuta
{
    public int Id { get; private set; }
    public string NombreEstado { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    protected EstadoRuta() { }

    public EstadoRuta(string nombreEstado, string descripcion)
    {
        NombreEstado = nombreEstado;
        Descripcion = descripcion;
        EsActivo = true;
    }
}
