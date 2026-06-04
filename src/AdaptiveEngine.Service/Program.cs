using AdaptiveEngine.Service.Application;
using AdaptiveEngine.Service.Infrastructure;
using AdaptiveEngine.Service.Infrastructure.Persistence;
using AdaptiveEngine.Service.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Layer Registrations (Clean Architecture)
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



// Minimal APIs (Presentation Layer delegating to Application Layer)
var api = app.MapGroup("/api/v1/adaptive-engine");

api.MapPost("/perfil-estudiante/actualizar-nivel", async (
    [FromBody] ActualizarNivelAprendizajeCommand command, 
    IMediator mediator) =>
{
    try
    {
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message); // In a real app use a global exception handler
    }
});

// Ensure database is created (para desarrollo)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AdaptiveEngineContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.Run();