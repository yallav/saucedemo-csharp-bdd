using Drivers;
using Reqnroll;

namespace Support
{
    [Binding]
    public class Hooks
    {
        private readonly IPlaywrightDriver _playwrightDriver;

        public Hooks(IPlaywrightDriver playwrightDriver)
        {
            _playwrightDriver = playwrightDriver;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            await _playwrightDriver.InitializeAsync();
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await _playwrightDriver.DisposeAsync();
        }
    }
}
