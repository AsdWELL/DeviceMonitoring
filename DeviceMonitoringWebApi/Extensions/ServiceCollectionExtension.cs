using DeviceMonitoringWebApi.Repositories;
using DeviceMonitoringWebApi.Repositories.Interfaces;
using DeviceMonitoringWebApi.Services;
using DeviceMonitoringWebApi.Services.Interfaces;
using Microsoft.OpenApi;

namespace DeviceMonitoringWebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddEndpointsApiExplorer()
                            .AddSwaggerGen(options =>
                            {
                                options.SwaggerDoc("DeviceMonitoring", new OpenApiInfo
                                {
                                    Version = "v1",
                                    Title = "Сервис мониторинга стороннего приложения",
                                    Description = $"Тестовое задание. Выполнил: Годов Д.А."
                                });
                            });
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IDeviceSessionRepository, DeviceSessionRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IDeviceSessionService, DeviceSessionService>();
        }
    }
}
