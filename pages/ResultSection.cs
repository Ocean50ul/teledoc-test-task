using Microsoft.Playwright;

public class ResultsSection : BasePage
{
    // Locators with selectors
    private ILocator Container => Page.Locator("[data-test='rightCol']");

    public ResultsSection(IPage page) : base(page) { }

    public async Task<AddressCodes> ExtractCodesAsync()
    {
        async Task<string> GetValue(string dataTest) =>
            await Container.Locator($"[data-test='{dataTest}']").InnerTextAsync();

        return new AddressCodes(
            Fias: await GetValue("fias-codes"),
            Oktmo: await GetValue("oktmo")
        );
    }
}