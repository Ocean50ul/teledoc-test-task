using Microsoft.Playwright;

public class SuggestionsPage : BasePage
{
    // Locators with selectors
    private ILocator TryItModule => Page.Locator("[data-test='motto-example']");

    // Webpage components
    public DemoForm DemoForm { get; }
    public GranularAddressForm GranularAddressForm { get; }
    public ResultsSection ResultsSection { get; }

    public SuggestionsPage(IPage page) : base(page)
    {
        DemoForm = new DemoForm(page);
        GranularAddressForm = new GranularAddressForm(page);
        ResultsSection = new ResultsSection(page);
    }

    // 3. Выполняется клик Нажать, чтобы попробовать вживую .
    public async Task SelectDemoScenarioAsync()
    {
        await TryItModule.ClickAsync();
        await WaitRandomAsync(1432, 3659);
    }
}