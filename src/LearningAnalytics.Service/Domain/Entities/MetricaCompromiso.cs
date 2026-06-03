namespace LearningAnalytics.Service.Domain.Entities;

public class MetricaCompromiso
{
    public int Id { get; private set; }
    public string EstudianteId { get; private set; } = string.Empty;
    public decimal PuntajeCompromiso { get; private set; }
    public int TiempoTotalMinutos { get; private set; }
    public int ContenidoCompletado { get; private set; }
    public DateTime FechaCalculo { get; private set; }
    public bool EsActivo { get; private set; }

    protected MetricaCompromiso() { }

    public MetricaCompromiso(string estudianteId)
    {
        EstudianteId = estudianteId;
        PuntajeCompromiso = 0;
        TiempoTotalMinutos = 0;
        ContenidoCompletado = 0;
        FechaCalculo = DateTime.UtcNow;
        EsActivo = true;
    }

    public void RecalcularCompromiso(int nuevosMinutos, int nuevasActividadesCompletadas)
    {
        TiempoTotalMinutos += nuevosMinutos;
        ContenidoCompletado += nuevasActividadesCompletadas;
        
        // Simple logic for engagement score: max 100
        decimal scoreBase = (TiempoTotalMinutos * 0.5m) + (ContenidoCompletado * 2.0m);
        PuntajeCompromiso = Math.Min(100m, scoreBase);
        
        FechaCalculo = DateTime.UtcNow;
    }
}
