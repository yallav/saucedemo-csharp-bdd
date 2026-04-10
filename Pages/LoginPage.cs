using Microsoft.Playwright;
using Saucedemo_Csharp_Bdd.Configurations;
using Saucedemo_Csharp_Bdd.Drivers;

namespace Saucedemo_Csharp_Bdd.Pages
{
    public interface ILoginPage
    {
        Task LoginAsync();
    }

    public class LoginPage(IPlaywrightDriver playwrightDriver, TestSettings testSettings) : ILoginPage
    {
        private IPage Page => playwrightDriver.Page
            ?? throw new InvalidOperationException("Playwright driver not initialized. Call InitializeAsync first.");

        private ILocator Username => Page.Locator("//input[@id='user-name']");
        private ILocator Password => Page.Locator("//input[@id='password']");
        private ILocator LoginButton => Page.Locator("//input[@id='login-button']");

        public async Task LoginAsync()
        {
            string? _userName = testSettings.Username ?? Environment.GetEnvironmentVariable("Username");
            string? _password = testSettings.Password ?? Environment.GetEnvironmentVariable("Password");

            if (string.IsNullOrEmpty(_userName) && string.IsNullOrEmpty(_password))
                throw new InvalidOperationException("Username and Password must be provided either through configuration or environment variables.");

            await Username.FillAsync(_userName!);
            await Password.FillAsync(_password!);
            await LoginButton.ClickAsync();
        }
    }
}
