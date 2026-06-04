using Assessment.Service.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Service.Presentation.Endpoints;

public static class EvaluacionEndpoints
{
    public static void MapEvaluacionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/assessment/evaluaciones").WithTags("Evaluaciones");

        group.MapGet("/", async ([FromServices] IMediator mediator) =>
        {
            var evaluaciones = await mediator.Send(new ObtenerEvaluacionesQuery());
            return Results.Ok(evaluaciones);
        })
        .WithName("ObtenerEvaluaciones")
        .WithDescription("Obtiene la lista de todas las evaluaciones disponibles");

        group.MapGet("/{id:int}", async (int id, [FromServices] IMediator mediator) =>
        {
            var evaluacion = await mediator.Send(new ObtenerEvaluacionPorIdQuery(id));
            return evaluacion is not null ? Results.Ok(evaluacion) : Results.NotFound();
        })
        .WithName("ObtenerEvaluacionPorId")
        .WithDescription("Obtiene los detalles de una evaluación específica por su ID");
    }
}
