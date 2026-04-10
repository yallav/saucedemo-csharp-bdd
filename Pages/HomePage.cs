using Configurations;
using Drivers;
using Microsoft.Extensions.Options;
using Microsoft.Playwright;

namespace Saucedemo_Csharp_Bdd.Pages
{
    public interface IHomePage
    {
        Task NavigateAsync();
    }

    public class HomePage(IPlaywrightDriver playwrightDriver, IOptions<TestSettings> testSettings) : IHomePage
    {
        private readonly IPlaywrightDriver _playwrightDriver = playwrightDriver;
        private readonly TestSettings _testSettings = testSettings.Value;

        private IPage Page => _playwrightDriver.Page 
            ?? throw new InvalidOperationException("Playwright driver not initialized. Call InitializeAsync first.");

        public async Task NavigateAsync()
        {
            string? _applicationUrl = _testSettings.BaseUrl ?? Environment.GetEnvironmentVariable("BaseUrl");
                
            if (string.IsNullOrEmpty(_applicationUrl))
                    throw new InvalidOperationException("Application URL must be provided either through configuration or environment variables.");

            await Page.GotoAsync(_applicationUrl);
        }
    }
}
