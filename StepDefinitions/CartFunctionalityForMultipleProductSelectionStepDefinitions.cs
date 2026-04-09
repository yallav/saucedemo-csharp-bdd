using Shouldly;
using Saucedemo_Csharp_Bdd.Pages;

namespace Saucedemo_Csharp_Bdd.StepDefinitions
{
    [Binding]
    public class CartFunctionalityForMultipleProductSelectionStepDefinitions(
        ScenarioContext sc,
        IHomePage homePage,
        ILoginPage loginPage,
        IProductsPage productsPage,
        ICartPage cartPage)
    {
        [Given("I navigate to the SauceDemo login page")]
        public async Task GivenINavigateToTheSauceDemoLoginPage()
        {
            await homePage.NavigateAsync();
        }

        [When("I login with valid credentials")]
        public async Task WhenILoginWithValidCredentials()
        {
            await loginPage.LoginAsync();
        }

        [Then("I should land on the products page with page title {string} and atleast two products")]
        public async Task ThenIShouldLandOnTheProductsPageWithPageTitleAndAtleastTwoProducts(string expectedPageTitle)
        {
            var actualPageTitle = await productsPage.GetPageTitleAsync();
            int actualProductCount = await productsPage.GetProductCountAsync();

            actualPageTitle.ShouldBe(expectedPageTitle);
            actualProductCount.ShouldBeGreaterThanOrEqualTo(2);
        }

        [When("I open the first product details page")]
        public async Task WhenIOpenTheFirstProductDetailsPage()
        {
            await productsPage.ClickOnProductByIndexAsync(0);
            var firstProductName = await productsPage.GetProductNameAsync();
            sc.Add("FirstProductName",firstProductName );
        }

        [When("I add the product to the cart")]
        public async Task WhenIAddTheProductToTheCart()
        {
            (await productsPage.IsAddToCartButtonVisibleForProduct()).ShouldBeTrue();
            await productsPage.ClickAddToCartButtonAsync();
        }

        [When("I navigate back to the products page")]
        public async Task WhenINavigateBackToTheProductsPage()
        {
            await productsPage.NavigateBackToProductsPageAsync();
        }

        [When("I open the second product details page")]
        public async Task WhenIOpenTheSecondProductDetailsPage()
        {
            await productsPage.ClickOnProductByIndexAsync(1);
            var secondProductName = await productsPage.GetProductNameAsync();
            sc.Add("SecondProductName", secondProductName);
        }

        [When("I navigate to the cart page")]
        public async Task WhenINavigateToTheCartPage()
        {
            await productsPage.ClickOnCartLinkAsync();
        }

        [Then("I should see {int} products in the cart")]
        public async Task ThenIShouldSeeProductsInTheCart(int expectedProductsCount)
        {
            var actualProductCount = await cartPage.GetProductCountAsync();
            actualProductCount.ShouldBe(expectedProductsCount);
        }

        [Then("each product should have a {string} button")]
        public async Task ThenEachProductShouldHaveAButton(string expectedButtonTitle)
        {
            (await cartPage.GetRemoveButtonCountAsync()).ShouldBe(2);

            var productContainers = await cartPage.GetProductContainersAsync();
            var firstProductName = sc.Get<string>("FirstProductName");
            var secondProductName = sc.Get<string>("SecondProductName");

            productContainers.Where(item => item.Contains(firstProductName)).ShouldNotBeEmpty();
            productContainers.Where(item => item.Contains(secondProductName)).ShouldNotBeEmpty();

            foreach (var item in productContainers)
            {
                item.ShouldContain(expectedButtonTitle);
            }
        }

        [Then("I should see a {string} button")]
        public async Task ThenIShouldSeeAButton(string expectedButtonTitle)
        {
            var isButtonVisible = await cartPage.IsElementVisibleAsync(expectedButtonTitle);
            isButtonVisible.ShouldBeTrue();
        }
    }
}
