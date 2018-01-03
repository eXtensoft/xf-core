using eXtensoft.XF.Core.Abstractions;
using eXtensoft.XF.Data.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace eXtensoft.Demo.Consolas
{
    class Program
    {
        static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();


            Console.WriteLine("Hello World!");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new LoggerFactory().AddConsole().AddDebug());
            services.AddLogging();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
            services.AddOptions();
            //services.Configure<QueueSettings>(configuration.GetSection("QueueSettings"));
            services.AddSingleton<IConfiguration>(configuration);
            //services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();
            //services.AddTransient<ISerializer, JsonMessageSerializer>();
            //services.AddSingleton<IQueueConsumer, TenantQueueConsumer>();
            //services.AddTransient<DP.Search.Suggestive.Abstractions.ITenantProvider, TenantProvider>();
            //services.AddTransient<DP.Queues.Search.Suggestive.ITenantProvider, DP.Search.Suggestive.Data.MongoDb.Queues.TenantProvider>();

        }

        private static IDataService GetService()
        {
            return null; 
        }
    }
}
