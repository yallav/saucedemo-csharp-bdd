using Drivers;
using Microsoft.Playwright;

namespace Saucedemo_Csharp_Bdd.Pages
{
    public interface ICartPage
    {
        Task<int> GetProductCountAsync();
        Task<int> GetRemoveButtonCountAsync();
        Task<string[]> GetProductContainersAsync();
        Task<bool> IsElementVisibleAsync(string elementName);
    }

    public class CartPage(IPlaywrightDriver playwrightDriver) : ICartPage
    {
        private IPage Page => playwrightDriver.Page
            ?? throw new InvalidOperationException("Playwright driver not initialized. Call InitializeAsync first.");

        private ILocator ProductItems => Page.Locator("//div[@data-test='inventory-item']");
        private ILocator RemoveButton => Page.Locator("//button[contains(@id,'remove')]");
        private ILocator ContinueShoppingButton => Page.Locator("//button[@id='continue-shopping']");
        private ILocator CheckoutButton => Page.Locator("//button[@id='checkout']");

        public async Task<int> GetProductCountAsync() => await ProductItems.CountAsync();

        public async Task<int> GetRemoveButtonCountAsync() => await RemoveButton.CountAsync();

        public async Task ClickContinueShoppingAsync() => await ContinueShoppingButton.ClickAsync();

        public async Task ClickCheckoutAsync() => await CheckoutButton.ClickAsync();

        public async Task<string[]> GetProductContainersAsync()
        {
            int count = await ProductItems.CountAsync();
            string[] productContainers = new string[count];
            for (int i = 0; i < count; i++)
            {
                productContainers[i] = await ProductItems.Nth(i).InnerHTMLAsync();
            }
            return productContainers;
        }

        public async Task<bool> IsElementVisibleAsync(string elementName)
        {
            var locator = await GetTheLocator(elementName);
            return await locator.IsVisibleAsync();
        }

        private async Task<ILocator> GetTheLocator(string elementName)
        {
            return elementName switch
            {
                "Continue Shopping" => ContinueShoppingButton,
                "Checkout" => CheckoutButton,
                _ => throw new ArgumentException($"No locator found for element name: {elementName}")
            };
        }
    }
}
