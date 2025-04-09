using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Configuration;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.UseCases.RegistroUsuario;
using System.Reflection;
using Application.Configuration;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.ConfigureRepository();
        services.ConfigureServices();

        var connectionString = context.Configuration.GetConnectionString("BdReminder");

        services.AddDbContext<PruebaContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            });
        });
        services.AddMediatR(cfg => {
             cfg.RegisterServicesFromAssemblies(typeof(RegistroUsuarioComandHandler).GetTypeInfo().Assembly);
         });

    })
    .Build();


host.Run();