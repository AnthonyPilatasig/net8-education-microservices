using EducationPlataform.Service.Domain.Repositories;
using EducationPlataform.Service.Infrastructure.Persistence;
using EducationPlataform.Service.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MassTransit;

namespace EducationPlataform.Service.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<EducationPlatformContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32))));

        services.AddScoped<IInscripcionRepository, InscripcionRepository>();

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
