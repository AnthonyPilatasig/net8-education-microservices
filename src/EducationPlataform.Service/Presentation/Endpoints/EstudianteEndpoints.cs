using EducationPlataform.Service.Application.Commands;
using EducationPlataform.Service.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlataform.Service.Presentation.Endpoints;

public static class EstudianteEndpoints
{
    public static void MapEstudianteEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/education-platform/estudiantes")
                       .WithTags("Estudiantes");

        group.MapGet("/", async (IMediator mediator) =>
            Results.Ok(await mediator.Send(new ObtenerEstudiantesQuery())));

        group.MapGet("/{id}", async (string id, IMediator mediator) =>
        {
            var estudiante = await mediator.Send(new ObtenerEstudiantePorIdQuery(id));
            return estudiante is null ? Results.NotFound() : Results.Ok(estudiante);
        });

        group.MapPost("/", async ([FromBody] CrearEstudianteCommand command, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
    }
}
