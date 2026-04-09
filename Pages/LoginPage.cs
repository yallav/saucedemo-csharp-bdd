using Configurations;
using Drivers;
using Microsoft.Extensions.Options;
using Microsoft.Playwright;

namespace Saucedemo_Csharp_Bdd.Pages
{
    public interface ILoginPage
    {
        Task LoginAsync();
    }

    public class LoginPage(IPlaywrightDriver playwrightDriver, IOptions<TestSettings> testSettings) : ILoginPage
    {
        private readonly TestSettings _testSettings = testSettings.Value;

        private IPage Page => playwrightDriver.Page 
            ?? throw new InvalidOperationException("Playwright driver not initialized. Call InitializeAsync first.");
        
        private ILocator Username => Page.Locator("//input[@id='user-name']");
        private ILocator Password => Page.Locator("//input[@id='password']");
        private ILocator LoginButton => Page.Locator("//input[@id='login-button']");

        public async Task LoginAsync()
        {
            await Username.FillAsync(_testSettings.Username);
            await Password.FillAsync(_testSettings.Password);
            await LoginButton.ClickAsync();
        }
    }
}
