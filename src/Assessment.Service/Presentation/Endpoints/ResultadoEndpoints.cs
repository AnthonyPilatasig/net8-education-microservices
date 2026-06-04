using Assessment.Service.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Service.Presentation.Endpoints;

public static class ResultadoEndpoints
{
    public static void MapResultadoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/assessment/resultados").WithTags("Resultados");

        group.MapPost("/", async ([FromBody] RegistrarResultadoEvaluacionCommand command, [FromServices] IMediator mediator) =>
        {
            var resultadoId = await mediator.Send(command);
            return Results.Ok(new { Mensaje = "Resultado registrado exitosamente, evento publicado.", ResultadoId = resultadoId });
        })
        .WithName("RegistrarResultado")
        .WithDescription("Registra un nuevo resultado de evaluación y publica el evento a RabbitMQ");
    }
}
