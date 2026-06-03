using CompetencyMapping.Service.Application;
using CompetencyMapping.Service.Infrastructure;
using CompetencyMapping.Service.Infrastructure.Persistence;
using CompetencyMapping.Service.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Layer Registrations
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Minimal APIs
var api = app.MapGroup("/api/v1/competency-mapping");

api.MapPost("/mapa-competencias/actualizar", async (
    [FromBody] ActualizarNivelDominioCommand command, 
    IMediator mediator) =>
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

// Ensure database is created (para desarrollo)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CompetencyMappingContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.Run();