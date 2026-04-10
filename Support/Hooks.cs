using Saucedemo_Csharp_Bdd.Drivers;

namespace Saucedemo_Csharp_Bdd.Support
{
    [Binding]
    public class Hooks(IPlaywrightDriver playwrightDriver)
    {
        [BeforeScenario]
        public async Task BeforeScenario()
        {
            await playwrightDriver.InitializeAsync();
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await playwrightDriver.DisposeAsync();
        }
    }
}
