using CompetencyMapping.Service.Domain.Repositories;
using CompetencyMapping.Service.Infrastructure.Persistence;
using CompetencyMapping.Service.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MassTransit;

namespace CompetencyMapping.Service.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<CompetencyMappingContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32))));

        services.AddScoped<IMapaCompetenciaEstudianteRepository, MapaCompetenciaEstudianteRepository>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<Application.Consumers.EvaluacionCompletadaConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
