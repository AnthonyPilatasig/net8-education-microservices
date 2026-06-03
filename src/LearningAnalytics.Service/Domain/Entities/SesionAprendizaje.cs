namespace LearningAnalytics.Service.Domain.Entities;

public class SesionAprendizaje
{
    public int Id { get; private set; }
    public string EstudianteId { get; private set; } = string.Empty;
    public DateTime FechaInicio { get; private set; }
    public DateTime? FechaFin { get; private set; }
    public int DuracionMinutos { get; private set; }
    public int ActividadesCompletadas { get; private set; }
    public bool EsActivo { get; private set; }

    protected SesionAprendizaje() { }

    public SesionAprendizaje(string estudianteId)
    {
        EstudianteId = estudianteId;
        FechaInicio = DateTime.UtcNow;
        ActividadesCompletadas = 0;
        EsActivo = true;
    }

    public void FinalizarSesion(int actividadesCompletadas)
    {
        FechaFin = DateTime.UtcNow;
        DuracionMinutos = (int)(FechaFin.Value - FechaInicio).TotalMinutes;
        ActividadesCompletadas = actividadesCompletadas;
    }
}
