using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using Saucedemo_Csharp_Bdd.Configurations;
using Saucedemo_Csharp_Bdd.Drivers;
using Saucedemo_Csharp_Bdd.Pages;

namespace Saucedemo_Csharp_Bdd.Infrastructure
{
    public static class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            var environment = Environment.GetEnvironmentVariable("TEST_ENV") ?? "QA";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Configurations/appsettings.json", optional: false)
                .AddJsonFile($"Configurations/appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var testSettings = configuration
                    .GetSection("TestSettings")
                    .Get<TestSettings>()
                    ?? throw new Exception("TestSettings configuration is missing");

            services.AddSingleton(testSettings);
            services.AddSingleton<IPlaywrightDriver, PlaywrightDriver>();
            services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<ILoginPage, LoginPage>();
            services.AddScoped<IProductsPage, ProductsPage>();
            services.AddScoped<ICartPage, CartPage>();

            return services;
        }
    }
}
