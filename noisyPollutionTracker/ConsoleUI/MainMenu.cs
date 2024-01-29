using noisyPollutionTracker.ConsoleUI.SubMenus;
using noisyPollutionTracker.Services;
using noisyPollutionTracker.Services.API;
using Spectre.Console;

namespace noisyPollutionTracker.ConsoleUI;

public class MainMenu
{
    private CityAPI cityAPI;
    private CityService cityService;
    private AgentService agentService;

    CityMenu cityMenu;
    AgentMenu agentMenu;
    public MainMenu()
    {
        cityAPI = new CityAPI();
        cityAPI.GetDataAsync().Wait();

        var CityList = cityAPI.GetCities();

        cityService = new CityService(CityList);
        agentService = new AgentService(cityService);


        cityMenu = new CityMenu(cityService);
        agentMenu = new AgentMenu(agentService);

    }

    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            var choise = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[royalblue1]Noisy[/][aqua] Pollution[/][darkolivegreen3_1] Tracker[/]")
                    .PageSize(4)
                    .AddChoices(new[] {
                        "Get cities from API",
                        "Manage Agents\n",
                        "[red]Exit[/]"}));

            switch (choise)
            {
                case "Get cities from API":
                    Console.Clear();
                    cityMenu.Display();
                    break;

                case "Manage Agents\n":
                    Console.Clear();
                    agentMenu.Display();
                    break;

                case "[red]Exit[/]":
                    return;
            }
        }
    }
}
