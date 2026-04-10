using Microsoft.Playwright;
using Saucedemo_Csharp_Bdd.Drivers;

namespace Saucedemo_Csharp_Bdd.Pages
{
    public interface IProductsPage
    {
        Task<string?> GetPageTitleAsync();
        Task<int> GetProductCountAsync();
        Task OpenTheItemAsync();
        Task<string> GetProductNameAsync();
        Task<bool> IsAddToCartButtonVisibleForProduct();
        Task ClickAddToCartButtonAsync();
        Task NavigateBackToProductsPageAsync();
        Task ClickOnCartLinkAsync();
    }

    public class ProductsPage(IPlaywrightDriver playwrightDriver) : IProductsPage
    {
        private IPage Page => playwrightDriver.Page
            ?? throw new InvalidOperationException("Playwright driver not initialized. Call InitializeAsync first.");

        private ILocator PageTitle => Page.Locator("//span[@class='title']");
        private ILocator ProductItems => Page.Locator("//div[@class='inventory_item']");
        private ILocator ProductName => Page.Locator("//div[@data-test='inventory-item-name']");
        private ILocator AddToCartButton => Page.Locator("//button[contains(@class, 'btn_inventory')]");
        private ILocator BackToProductsButton => Page.Locator("//button[@id='back-to-products']");
        private ILocator CartLink => Page.Locator("//a[@class='shopping_cart_link']");

        public async Task<string?> GetPageTitleAsync() => await PageTitle.TextContentAsync();

        public async Task<int> GetProductCountAsync() => await ProductItems.CountAsync();

        public async Task OpenTheItemAsync()
        {
            int randiIndex = await GetProductIndexWhichIsAvailableToAddToCart();
            await ProductItems.Nth(randiIndex).Locator("//a[contains(@id,'item') and contains(@id,'img')]").ClickAsync();
        }

        public async Task<string> GetProductNameAsync()
        {
            return await ProductName.TextContentAsync() ?? string.Empty;
        }

        public async Task<bool> IsAddToCartButtonVisibleForProduct()
        {
            return await AddToCartButton.IsVisibleAsync();
        }

        public async Task ClickAddToCartButtonAsync()
        {
            await AddToCartButton.ClickAsync();
        }

        public async Task NavigateBackToProductsPageAsync()
        {
            await BackToProductsButton.ClickAsync();
        }

        public async Task ClickOnCartLinkAsync()
        {
            await CartLink.ClickAsync();
        }

        private async Task<int> GetProductIndexWhichIsAvailableToAddToCart()
        {
            int count = await ProductItems.CountAsync();
            int randomIndex = new Random().Next(0, count);

            if (await AddToCartButton.Nth(randomIndex).IsVisibleAsync() &&
                await ProductItems.Nth(randomIndex).Locator("//button[text()='Add to cart']").IsVisibleAsync())

                return randomIndex;
            else
                return -1;
        }
    }
}
