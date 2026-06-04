using EducationPlataform.Service.Application;
using EducationPlataform.Service.Infrastructure;
using EducationPlataform.Service.Infrastructure.Persistence;
using EducationPlataform.Service.Application.Commands;
using EducationPlataform.Service.Application.Queries;
using EducationPlataform.Service.Presentation.Endpoints;
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



// Minimal APIs organizadas por dominio
app.MapEstudianteEndpoints();
app.MapCursoEndpoints();
app.MapInscripcionEndpoints();

// Ensure database is created (para desarrollo)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EducationPlatformContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.Run();