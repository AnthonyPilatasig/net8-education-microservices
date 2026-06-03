namespace ContentPersonalization.Service.Domain.Entities;

public class ModeloRuta
{
    public int Id { get; private set; }
    public int RutaAprendizajeId { get; private set; }
    public int ContenidoId { get; private set; }
    public int OrdenModulo { get; private set; }
    public DateTime FechaAsignacion { get; private set; }
    public DateTime? FechaCompletacion { get; private set; }
    public bool EsActivo { get; private set; }

    public virtual RutaAprendizaje? RutaAprendizaje { get; private set; }

    protected ModeloRuta() { }

    public ModeloRuta(int rutaAprendizajeId, int contenidoId, int ordenModulo)
    {
        RutaAprendizajeId = rutaAprendizajeId;
        ContenidoId = contenidoId;
        OrdenModulo = ordenModulo;
        FechaAsignacion = DateTime.UtcNow;
        EsActivo = true;
    }

    public void CompletarModulo()
    {
        FechaCompletacion = DateTime.UtcNow;
    }
}
