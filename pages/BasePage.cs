using Microsoft.Playwright;

public class BasePage
{
    protected IPage Page { get; }
    private static readonly Random Rng = new();

    public BasePage(IPage page)
    {
        Page = page;
    }

    protected async Task WaitRandomAsync(int min = 800, int max = 3000)
    {
        await Task.Delay(Rng.Next(min, max));
    }
}