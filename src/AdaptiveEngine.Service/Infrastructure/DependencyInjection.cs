using AdaptiveEngine.Service.Domain.Repositories;
using AdaptiveEngine.Service.Infrastructure.Persistence;
using AdaptiveEngine.Service.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MassTransit;

namespace AdaptiveEngine.Service.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<AdaptiveEngineContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32))));

        services.AddScoped<IPerfilEstudianteRepository, PerfilEstudianteRepository>();


        services.AddMassTransit(x =>
        {
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
