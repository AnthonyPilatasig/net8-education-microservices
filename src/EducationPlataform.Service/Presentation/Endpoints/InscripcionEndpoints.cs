using EducationPlataform.Service.Application.Commands;
using EducationPlataform.Service.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlataform.Service.Presentation.Endpoints;

public static class InscripcionEndpoints
{
    public static void MapInscripcionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/education-platform/inscripciones")
                       .WithTags("Inscripciones");

        group.MapGet("/estudiante/{idEstudiante}", async (string idEstudiante, IMediator mediator) =>
            Results.Ok(await mediator.Send(new ObtenerInscripcionesEstudianteQuery(idEstudiante))));

        group.MapPost("/", async ([FromBody] InscribirEstudianteCommand command, IMediator mediator) =>
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
