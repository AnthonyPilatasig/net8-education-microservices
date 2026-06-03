using ContentPersonalization.Service.Domain.Repositories;
using ContentPersonalization.Service.Infrastructure.Persistence;
using ContentPersonalization.Service.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MassTransit;

namespace ContentPersonalization.Service.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<ContentPersonalizationContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IRutaAprendizajeRepository, RutaAprendizajeRepository>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<Application.Consumers.MapaCompetenciasActualizadoConsumer>();

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
