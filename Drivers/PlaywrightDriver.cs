using Microsoft.Playwright;
using Saucedemo_Csharp_Bdd.Configurations;

namespace Saucedemo_Csharp_Bdd.Drivers
{
    public interface IPlaywrightDriver
    {
        IBrowser? Browser { get; }
        IBrowserContext? Context { get; }
        IPage? Page { get; }
        Task DisposeAsync();
        Task InitializeAsync();
    }

    public class PlaywrightDriver(TestSettings testsettings) : IPlaywrightDriver
    {
        private readonly TestSettings _testSettings = testsettings;
        private IPlaywright? _playwright;
        public IBrowser? Browser { get; private set; }
        public IBrowserContext? Context { get; private set; }
        public IPage? Page { get; private set; }

        public async Task InitializeAsync()
        {
            _playwright = await Playwright.CreateAsync();

            BrowserTypeLaunchOptions options = new()
            {
                Headless = _testSettings.Headless,
                SlowMo = _testSettings.SlowMo
            };

            Browser = _testSettings.Browser.ToLower() switch
            {
                "chromium" => await _playwright[_testSettings.Browser].LaunchAsync(options),
                "firefox" => await _playwright[_testSettings.Browser].LaunchAsync(options),
                "webkit" => await _playwright[_testSettings.Browser].LaunchAsync(options),
                _ => throw new ArgumentException($"Unsupported browser: {_testSettings.Browser}")
            };

            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        public async Task DisposeAsync()
        {
            if (Page != null)
                await Page.CloseAsync();
            if (Context != null)
                await Context.CloseAsync();
            if (Browser != null)
                await Browser.CloseAsync();
            _playwright?.Dispose();
        }
    }
}
