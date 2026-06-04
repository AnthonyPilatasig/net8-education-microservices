using LearningAnalytics.Service.Application;
using LearningAnalytics.Service.Infrastructure;
using LearningAnalytics.Service.Infrastructure.Persistence;
using LearningAnalytics.Service.Application.Commands;
using LearningAnalytics.Service.Presentation.Endpoints;
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
app.MapEventosEndpoints();
app.MapMetricasEndpoints();

// Ensure database is created (para desarrollo)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LearningAnalyticsContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.Run();