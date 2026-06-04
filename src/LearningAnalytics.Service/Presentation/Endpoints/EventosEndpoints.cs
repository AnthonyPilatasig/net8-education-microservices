using LearningAnalytics.Service.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningAnalytics.Service.Presentation.Endpoints;

public static class EventosEndpoints
{
    public static void MapEventosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/learning-analytics/eventos")
                       .WithTags("Eventos de Aprendizaje");

        group.MapPost("/", async ([FromBody] RegistrarEventoAprendizajeCommand command, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
    }
}
