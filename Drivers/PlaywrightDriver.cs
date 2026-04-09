using Configurations;
using Microsoft.Extensions.Options;
using Microsoft.Playwright;

namespace Drivers
{
    public class PlaywrightDriver : IPlaywrightDriver
    {
        private TestSettings _testSettings;
        private IPlaywright? _playwright;
        public IBrowser? Browser { get; private set; }
        public IBrowserContext? Context { get; private set; }
        public IPage? Page { get; private set; }

        public PlaywrightDriver(IOptions<TestSettings> testsettings)
        {
            _testSettings = testsettings.Value;
        }

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
