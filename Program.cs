using Microsoft.Playwright;

public class DadataTester
{
    public static async Task Test(string address)
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
        var page = await browser.NewPageAsync();

        var homePage = new HomePage(page);
        await homePage.GoToAsync();

        var suggestionsPage = await homePage.NavigateToSuggestionsAsync();
        await suggestionsPage.SelectDemoScenarioAsync();

        await suggestionsPage.DemoForm.FillAsync(address);
        var correctedAddress = await suggestionsPage.DemoForm.ExtractAddressAsync();

        await suggestionsPage.GranularAddressForm.FillAsync(correctedAddress);
        var codes = await suggestionsPage.ResultsSection.ExtractCodesAsync();

        // 10. Вывод результатов
        Console.WriteLine($"\nФИАС: {codes.Fias}\nОКТМО: {codes.Oktmo}");

        // 11. Ожидание закрытия браузера
        Console.WriteLine("\nPress 'q' to quit and close browser.");
        while (true)
        {
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Q)
                break;
        }

        await browser.CloseAsync();
    }
}

class Program
{
    public static async Task Main(string[] args)
    {
        // var address = "г НЕжний НАвгород, наб им Федоровского, д 2/13, оф 10"
        var address = "г НЕжний НАвгород, наб им Федоровского, д 2/13, кв 13";
        await DadataTester.Test(address);

    }
}