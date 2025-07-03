using Microsoft.Playwright;

public class DemoForm : BasePage
{
    // Locators with selectors
    private ILocator Checkboxes => Page.Locator("[data-test='demo-toggler-component'] label.input-checkbox-btn");
    private ILocator FormInput => Page.Locator("[data-test='demo-form'] input");
    private ILocator FirstSuggestion => Page.Locator("[data-test='demo-form'] .suggestions-wrapper [data-index='0']");
    private ILocator ResultsContainer => Page.Locator("[data-test='demo-results-component']");

    public DemoForm(IPage page) : base(page) { }

    public async Task FillAsync(string address)
    {
        // 4. Ставится отметка в муниципальном делении .
        await Checkboxes.Nth(2).ClickAsync();
        await WaitRandomAsync(1432, 3659);
        
        // 5. Вводится в текстовое поле входной адрес.
        await FormInput.FillAsync(address);
        await WaitRandomAsync(1432, 3659);

        // 6. Из всплывающего списка выбирается первый подходящий вариант.
        await FirstSuggestion.ClickAsync();
        await WaitRandomAsync(1432, 3659);
    }

    // 7. Запоминается каким-либо образом отображаемая информация, а конкретно разделы Регион, Район, Город, Улица, Дом, Квартира.
    public async Task<Address> ExtractAddressAsync()
    {
        async Task<string> GetValue(string dataTest) =>
            await ResultsContainer.Locator($"[data-test='{dataTest}']").InnerTextAsync();

        return new Address(
            Region: await GetValue("region"),
            District: await GetValue("area"),
            City: await GetValue("city"),
            Street: await GetValue("street"),
            House: await GetValue("house"),
            Flat: await GetValue("flat")
        );
    }
}