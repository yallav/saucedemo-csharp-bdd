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
            await Page.GotoAsync(_testSettings.BaseUrl);
        }
    }
}
