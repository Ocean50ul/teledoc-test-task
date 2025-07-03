using Microsoft.Playwright;

public class GranularAddressForm : BasePage
{
    // Locators with selectors
    private ILocator GranularAddressTab => Page.Locator("[data-test='address-granular']");
    private ILocator FormContainer => Page.Locator("[data-test='demo-custom-form-component']");
    private ILocator FirstSuggestion => FormContainer.Locator("[data-index='0']");

    public GranularAddressForm(IPage page) : base(page) { }

    // Метод для заполнения полей по корректному адресу
    public async Task FillAsync(Address address)
    {
        // 8. Выполняется переход на соседний раздел Адрес по полям .
        await GranularAddressTab.ClickAsync();
        await WaitRandomAsync(1432, 3659);

        // 9. В каждое текстовое поле вводится соответствующее значение с предыдущего шага Регион, Район и т.д. с выбором первого значения из
        // всплывающего списка в каждом случае.

        // Заполнение региона и выбор первой подсказки
        var regionInput = FormContainer.Locator("[data-test='region']");
        await regionInput.FillAsync(address.Region);
        await WaitRandomAsync(1432, 3659);
        await FirstSuggestion.ClickAsync();
        await WaitRandomAsync(1432, 3659);

        // Заполнение города и выбор первой подсказки
        var cityInput = FormContainer.Locator("[data-test='city']");
        await cityInput.FillAsync(address.City);
        await WaitRandomAsync(1432, 3659);
        await FirstSuggestion.ClickAsync();
        await WaitRandomAsync(1432, 3659);

        // Заполнение улицы и выбор первой подсказки
        var streetInput = FormContainer.Locator("[data-test='street']");
        await streetInput.FillAsync(address.Street);
        await WaitRandomAsync(1432, 3659);
        await FirstSuggestion.ClickAsync();
        await WaitRandomAsync(1432, 3659);

        // Заполнение дома и выбор первой подсказки
        var houseInput = FormContainer.Locator("[data-test='house']");
        await houseInput.FillAsync(address.House);
        await WaitRandomAsync(1432, 3659);
        await FirstSuggestion.ClickAsync();
        await WaitRandomAsync(1432, 3659);

        // Заполнение квартиры
        var flatInput = FormContainer.Locator("[data-test='flat'] input[name='flat']");
        await flatInput.FillAsync(address.Flat);
        await WaitRandomAsync(1432, 3659);
    }
}