using Configurations;
using Drivers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using Saucedemo_Csharp_Bdd.Pages;

namespace Saucedemo_Csharp_Bdd.Infrastructure
{
    public static class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Configurations/appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            services.Configure<TestSettings>(options => configuration.GetSection("TestSettings").Bind(options));
            services.AddSingleton<IConfiguration>(configuration);

            services.AddScoped<IPlaywrightDriver, PlaywrightDriver>();
            services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<ILoginPage, LoginPage>();
            services.AddScoped<IProductsPage, ProductsPage>();
            services.AddScoped<ICartPage, CartPage>();

            return services;
        }
    }
}
