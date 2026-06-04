using EducationPlataform.Service.Application.Commands;
using EducationPlataform.Service.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlataform.Service.Presentation.Endpoints;

public static class CursoEndpoints
{
    public static void MapCursoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/education-platform/cursos")
                       .WithTags("Cursos");

        group.MapGet("/", async (IMediator mediator) =>
            Results.Ok(await mediator.Send(new ObtenerCursosQuery())));

        group.MapGet("/{id}", async (int id, IMediator mediator) =>
        {
            var curso = await mediator.Send(new ObtenerCursoPorIdQuery(id));
            return curso is null ? Results.NotFound() : Results.Ok(curso);
        });

        group.MapPost("/", async ([FromBody] CrearCursoCommand command, IMediator mediator) =>
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
