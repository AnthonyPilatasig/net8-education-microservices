namespace LearningAnalytics.Service.Domain.Entities;

public class TipoEvento
{
    public int Id { get; private set; }
    public string NombreEvento { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    private readonly List<EventoAprendizaje> _eventosAprendizaje = new();
    public virtual IReadOnlyCollection<EventoAprendizaje> EventosAprendizaje => _eventosAprendizaje.AsReadOnly();

    protected TipoEvento() { }

    public TipoEvento(string nombreEvento, string descripcion)
    {
        NombreEvento = nombreEvento;
        Descripcion = descripcion;
        EsActivo = true;
    }
}
