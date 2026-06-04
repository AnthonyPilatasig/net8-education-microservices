using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configurar Swagger (Agregador)
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Configuración de JWT Security
var jwtKey = builder.Configuration["Jwt:Key"] ?? "super_secret_key_for_education_platform_which_is_very_long";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "EducationPlatformIssuer";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "EducationPlatformAudience";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

// Se define la política 'default' que YARP requerirá
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("jwtAuth", policy => policy.RequireAuthenticatedUser());
});

// Añadir YARP
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseCors("AllowAll");

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger-docs/education/swagger.json", "Education Platform");
    c.SwaggerEndpoint("/swagger-docs/learning-analytics/swagger.json", "Learning Analytics");
    c.SwaggerEndpoint("/swagger-docs/content-personalization/swagger.json", "Content Personalization");
    c.SwaggerEndpoint("/swagger-docs/assessment/swagger.json", "Assessment");
    c.SwaggerEndpoint("/swagger-docs/adaptive-engine/swagger.json", "Adaptive Engine");
    c.SwaggerEndpoint("/swagger-docs/competency-mapping/swagger.json", "Competency Mapping");
});

app.UseAuthentication();
app.UseAuthorization();

// Endpoint MOCK de Login para emitir tokens JWT válidos
app.MapPost("/api/v1/auth/login", (LoginRequest request) =>
{
    // Validar usuario (Mock simple para pruebas)
    if (request.Username == "admin" && request.Password == "admin123")
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "ADMIN-001"),
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, "Administrador")
        };

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)), 
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return Results.Ok(new { Token = tokenString });
    }
    
    return Results.Unauthorized();
});

// Mapear YARP (Aplicará las políticas definidas en appsettings)
app.MapReverseProxy();

app.Run();

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
