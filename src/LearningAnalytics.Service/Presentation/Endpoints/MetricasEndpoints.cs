using LearningAnalytics.Service.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningAnalytics.Service.Presentation.Endpoints;

public static class MetricasEndpoints
{
    public static void MapMetricasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/learning-analytics/metricas")
                       .WithTags("Métricas de Aprendizaje");

        group.MapGet("/estudiante/{idEstudiante}", async (string idEstudiante, IMediator mediator) =>
        {
            var metrica = await mediator.Send(new ObtenerMetricasPorEstudianteQuery(idEstudiante));
            return metrica is null ? Results.NotFound() : Results.Ok(metrica);
        });
    }
}
