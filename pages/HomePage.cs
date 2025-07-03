using Microsoft.Playwright;

public class HomePage : BasePage
{
    // Locaators with selectors
    private ILocator ProductsMenu => Page.Locator("header.header [data-test='menu-dropdown']");
    private ILocator SuggestionsLink => Page.Locator("[data-test='dropdown'] [data-test='link'][href='/suggestions/']");

    public HomePage(IPage page) : base(page) { }

    // 1. Автоматически открывается браузер со стартовой страницей https://dadata.ru.
    public async Task GoToAsync()
    {
        await Page.GotoAsync("https://dadata.ru/");
        await WaitRandomAsync(1432, 3659);
    }

    // 2. Раскрывается пункт меню Продукты => Подсказки .
    public async Task<SuggestionsPage> NavigateToSuggestionsAsync()
    {
        await ProductsMenu.ClickAsync();
        await WaitRandomAsync(1432, 3659);
        await SuggestionsLink.ClickAsync();
        await WaitRandomAsync(1432, 3659);

        return new SuggestionsPage(Page);
    }
}