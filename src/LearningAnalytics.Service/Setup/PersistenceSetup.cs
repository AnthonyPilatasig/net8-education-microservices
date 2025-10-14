using LearningAnalytics.Service.Common.Core.Persistence;
using LearningAnalytics.Service.Common;
using LearningAnalytics.Service.Common.Core.Helpers;
using LearningAnalytics.Service.Common.Core.Wrapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Net;


namespace LearningAnalytics.Service.Setup
{
    public static class PersistenceSetup
    {

        public static IServiceCollection AddContextInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuración para identificar si el Logging de la base de datos está activo
            bool.TryParse(configuration["DbContextSettings:Logging"].IfEmpty("false"), out bool loggingEnabled);
            bool.TryParse(configuration["DbContextSettings:EnableDetailedErrors"].IfEmpty("false"), out bool enableDetailedErrors);
            bool.TryParse(configuration["DbContextSettings:EnableSensitiveDataLogging"].IfEmpty("false"), out bool enableSensitiveDataLogging);
            int.TryParse(configuration["DbContextSettings:TimeOut"].IfEmpty("30"), out int dbExcecutionTimeOut);

            #region Analytics Context

            string? CdmiContextConnectionString = configuration.GetConnectionString(nameof(AnalyticsDbContext));
            services.AddDbContext<AnalyticsDbContext>(options =>
            {
                if (loggingEnabled)
                {
                    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddSerilog()));
                    if (enableDetailedErrors)
                    {
                        options.EnableDetailedErrors();
                    }
                    if (enableSensitiveDataLogging)
                    {
                        options.EnableSensitiveDataLogging();
                    }
                }

                options.UseMySql(
                    CdmiContextConnectionString,
                    ServerVersion.AutoDetect(CdmiContextConnectionString),
                    op => op.CommandTimeout(dbExcecutionTimeOut.Min(30)));

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseLazyLoadingProxies(true);
            }, ServiceLifetime.Transient);


            #endregion

            return services;
        }

        public static IServiceCollection AddRepositoryInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Código para generar automáticamnte la configuración de repositorios
            var repositoryTypes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(type => typeof(IRepository).IsAssignableFrom(type) && !type.IsAbstract)
                                  .ToArray();

            foreach (var repository in repositoryTypes)
            {
                services.AddTransient(repository);
            }

            services.AddSingleton<AppSettings>();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    {

                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    }

);
            return services;
        }

        public static IServiceCollection AddAuthenticationInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = true;
                o.SaveToken = false;
                var key = configuration["JWTSettings:Secret"];
                if (string.IsNullOrEmpty(key))
                {
                    throw new InvalidOperationException("JWT Secret key is missing in configuration");
                }
                var jwtSettings = configuration.GetSection("JWTSettings").Get<AppSettings>();
                if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.Secret))
                {
                    throw new InvalidOperationException("JWT Settings are missing in configuration");
                }
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };

                o.Events = new JwtBearerEvents()
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new Response(HttpStatusCode.Unauthorized, "Usted no está autorizado"));
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new Response(HttpStatusCode.Forbidden, "Usted no tiene permisos sobre este recurso"));
                        return context.Response.WriteAsync(result);
                    }
                };
            });

            return services;
        }

    }
}
