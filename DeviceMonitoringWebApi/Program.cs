using DeviceMonitoringWebApi.Extensions;
using DeviceMonitoringWebApi.Filters;
using DeviceMonitoringWebApi.Migration.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwagger();

builder.Services
    .AddDatabase(builder.Configuration)
    .AddRepositories()
    .AddServices();

builder.Services.AddControllers(options => options.Filters.Add<ExceptionFilter>());

var app = builder.Build();

app.UseCors(cors =>
{
    cors.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseSwagger()
    .UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/DeviceMonitoring/swagger.json", "DeviceMonitoring WebApi");
        options.RoutePrefix = string.Empty;
    });

app.MapControllers();

app.Run();