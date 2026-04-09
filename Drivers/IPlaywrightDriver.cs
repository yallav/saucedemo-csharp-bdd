using Microsoft.Playwright;

namespace Drivers
{
    public interface IPlaywrightDriver
    {
        IBrowser? Browser { get; }
        IBrowserContext? Context { get; }
        IPage? Page { get; }
        Task DisposeAsync();
        Task InitializeAsync();
    }
}