using Microsoft.Playwright;
using Saucedemo_Csharp_Bdd.Configurations;
using Saucedemo_Csharp_Bdd.Drivers;

namespace Saucedemo_Csharp_Bdd.Pages
{
    public interface IHomePage
    {
        Task NavigateAsync();
    }

    public class HomePage(IPlaywrightDriver playwrightDriver, TestSettings testSettings) : IHomePage
    {
        private IPage Page => playwrightDriver.Page 
            ?? throw new InvalidOperationException("Playwright driver not initialized. Call InitializeAsync first.");

        public async Task NavigateAsync()
        {
            string? _applicationUrl = testSettings.BaseUrl ?? Environment.GetEnvironmentVariable("BaseUrl");
                
            if (string.IsNullOrEmpty(_applicationUrl))
                    throw new InvalidOperationException("Application URL must be provided either through configuration or environment variables.");

            await Page.GotoAsync(_applicationUrl);
        }
    }
}
