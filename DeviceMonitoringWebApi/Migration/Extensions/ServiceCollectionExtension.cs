using DbUp;
using Npgsql;
using System.Data;
using System.Reflection;

namespace DeviceMonitoringWebApi.Migration.Extensions
{
    public static class ServiceCollectionExtension
    {
        private const string DatabaseConnectionStringName = "DeviceSessionsDatabase";

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DatabaseConnectionStringName);

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Отсутствует строка подключения для БД");

            services
                .AddScoped<IDbConnection>(_ => new NpgsqlConnection(connectionString))
                .MigrateDatabase(connectionString);

            return services;
        }

        private static IServiceCollection MigrateDatabase(this IServiceCollection services, string connectionString)
        {
            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .WithTransaction()
                .WithVariablesDisabled()
                .LogToConsole()
                .Build();

            if (upgrader.IsUpgradeRequired())
            {
                upgrader.PerformUpgrade();
            }

            return services;
        }
    }
}
