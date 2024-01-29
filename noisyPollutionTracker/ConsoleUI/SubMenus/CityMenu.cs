using noisyPollutionTracker.models.CityModels;
using noisyPollutionTracker.Services;
using Spectre.Console;
using System.Linq;

namespace noisyPollutionTracker.ConsoleUI.SubMenus;

public class CityMenu
{
    private CityService cityService;
    public CityMenu(CityService cityService)
    {
        this.cityService = cityService;
    }

    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            var choise = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[royalblue1]Noisy[/][aqua] Pollution[/][darkolivegreen3_1] Tracker[/]")
                    .PageSize(8)
                    .AddChoices(new[] {
                        "Get City by ID",
                        "Get City by Name",
                        "Get City with neighbourhood cities",
                        "Get Cities by Country",
                        "Get All cities which is high level noise pullution",
                        "Get All cities which is moderate level noise pullution",
                        "Get All cities which is low level noise pullution\n",
                        "[red]Go back[/]"}));
            switch (choise)
            {
                case "Get City by ID":
                    Console.Clear();

                    var Cid = AnsiConsole.Ask<int>("Enter City's [green]ID[/]:");

                    var result = cityService.GetById(Cid);
                    var innerTable = new Table();

                    innerTable.AddColumn("[green]City ID[/]");
                    innerTable.AddColumn("[green]City Name[/]");
                    innerTable.AddColumn("[green]Country[/]");
                    innerTable.AddColumn("[green]Population[/]");
                    innerTable.AddColumn("[green]Noisy Pollution Level[/]");

                    if (result != null)
                    {
                       
                        innerTable.AddRow(
                            result.Id.ToString() + "\n",
                            result.Name + "\n",
                            result.Country + "\n",
                            result.Population.ToString() + "\n",
                            result.NoisyPollutionLevel.ToString() + "\n"
                        );
                    }
                    else
                    {
                        innerTable.AddRow("Empty", "Empty", "Empty", "Empty", "Empty");
                    }
                    AnsiConsole.Write(innerTable);
                    break;
                case "Get City by Name":

                    Console.Clear();

                    var Cname = AnsiConsole.Ask<string>("Enter City's [green]Name[/]:");

                    var Nresult = cityService.GetByCityName(Cname);
                    var Ntable= new Table();

                    Ntable.AddColumn("[green]City ID[/]");
                    Ntable.AddColumn("[green]City Name[/]");
                    Ntable.AddColumn("[green]Country[/]");
                    Ntable.AddColumn("[green]Population[/]");
                    Ntable.AddColumn("[green]Noisy Pollution Level[/]");

                    if (Nresult != null)
                    {

                        Ntable.AddRow(
                            Nresult.Id.ToString() + "\n",
                            Nresult.Name + "\n",
                            Nresult.Country + "\n",
                            Nresult.Population.ToString() + "\n",
                            Nresult.NoisyPollutionLevel.ToString() + "\n"
                        );
                    }
                    else
                    {
                        Ntable.AddRow("Empty", "Empty", "Empty", "Empty", "Empty");
                    }
                    AnsiConsole.Write(Ntable);
                    break;
                case "Get City with neighbourhood cities":
                    Console.Clear();

                    var CNname = AnsiConsole.Ask<string>("Enter City's [green]Name[/]:");

                    var CNresult = cityService.GetCityWithNeighourhoodCities(CNname);
                    var CNinnerTable = new Table();

                    CNinnerTable.AddColumn("[green]City ID[/]");
                    CNinnerTable.AddColumn("[green]City Name[/]");
                    CNinnerTable.AddColumn("[green]Country[/]");
                    CNinnerTable.AddColumn("[green]Population[/]");
                    CNinnerTable.AddColumn("[green]Noisy Pollution Level[/]");
                    CNinnerTable.AddColumn("[green]Neighborhood Cities[/]");

                    if (CNresult != null)
                    {
                        CNinnerTable.AddRow(
                            CNresult.Id.ToString() + "\n",
                            CNresult.Name + "\n",
                            CNresult.Country + "\n",
                            CNresult.Population.ToString() + "\n",
                            CNresult.NoisyPollutionLevel.ToString() + "\n",
                            CNresult.NeighbourhoodCities != null && CNresult.NeighbourhoodCities.Any() ?
                                string.Join(", ", CNresult.NeighbourhoodCities) + "\n" :
                                "No neighborhood cities found."
                        );

                    }
                    else
                    {
                        CNinnerTable.AddRow("Empty", "Empty", "Empty", "Empty", "Empty", "Empty");
                    }
                    AnsiConsole.Write(CNinnerTable);
                    break;
                case "Get Cities by Country":
                    Console.Clear();

                    var CCname = AnsiConsole.Ask<string>("Enter Country's [green]Name[/]:");

                    var CCresult = cityService.GetCitiesByCountry(CCname);
                    var CCinnerTable = new Table();

                    CCinnerTable.AddColumn("[green]City ID[/]");
                    CCinnerTable.AddColumn("[green]City Name[/]");
                    CCinnerTable.AddColumn("[green]Country[/]");
                    CCinnerTable.AddColumn("[green]Population[/]");
                    CCinnerTable.AddColumn("[green]Noisy Pollution Level[/]");

                    if (CCresult != null)
                    {
                        foreach (var city in CCresult)
                        {
                            CCinnerTable.AddRow(
                            city.Id.ToString() + "\n",
                            city.Name + "\n",
                            city.Country + "\n",
                            city.Population.ToString() + "\n",
                            city.NoisyPollutionLevel.ToString() + "\n"
                            );
                        }
                    }
                    else
                    {
                        CCinnerTable.AddRow("Empty", "Empty", "Empty", "Empty", "Empty");
                    }
                    AnsiConsole.Write(CCinnerTable);
                    break;
                case "Get All cities which is high level noise pullution":
                    Console.Clear();
                    var CHLresult = cityService.GetAllHighLevel();
                    var CHLinnerTable = new Table();

                    CHLinnerTable.AddColumn("[green]City ID[/]");
                    CHLinnerTable.AddColumn("[green]City Name[/]");
                    CHLinnerTable.AddColumn("[green]Country[/]");
                    CHLinnerTable.AddColumn("[green]Population[/]");
                    CHLinnerTable.AddColumn("[green]Noisy Pollution Level[/]");

                    if (CHLresult != null)
                    {
                        foreach (var city in CHLresult)
                        {
                            CHLinnerTable.AddRow(
                            city.Id.ToString() + "\n",
                            city.Name + "\n",
                            city.Country + "\n",
                            city.Population.ToString() + "\n",
                            city.NoisyPollutionLevel.ToString() + "\n"
                            );
                        }
                    }
                    else
                    {
                        CHLinnerTable.AddRow("Empty", "Empty", "Empty", "Empty", "Empty");
                    }
                    AnsiConsole.Write(CHLinnerTable);
                    break;
                case "Get All cities which is moderate level noise pullution":
                    Console.Clear();
                    var CMLresult = cityService.GetAllModerateLevel();
                    var CMLinnerTable = new Table();

                    CMLinnerTable.AddColumn("[green]City ID[/]");
                    CMLinnerTable.AddColumn("[green]City Name[/]");
                    CMLinnerTable.AddColumn("[green]Country[/]");
                    CMLinnerTable.AddColumn("[green]Population[/]");
                    CMLinnerTable.AddColumn("[green]Noisy Pollution Level[/]");

                    if (CMLresult != null)
                    {
                        foreach (var city in CMLresult)
                        {
                            CMLinnerTable.AddRow(
                            city.Id.ToString() + "\n",
                            city.Name + "\n",
                            city.Country + "\n",
                            city.Population.ToString() + "\n",
                            city.NoisyPollutionLevel.ToString() + "\n"
                            );
                        }
                    }
                    else
                    {
                        CMLinnerTable.AddRow("Empty", "Empty", "Empty", "Empty", "Empty");
                    }
                    AnsiConsole.Write(CMLinnerTable);
                    break;
                case "Get All cities which is low level noise pullution\n":
                    Console.Clear();
                    var CLLresult = cityService.GetAllLowLevel();
                    var CLLinnerTable = new Table();

                    CLLinnerTable.AddColumn("[green]City ID[/]");
                    CLLinnerTable.AddColumn("[green]City Name[/]");
                    CLLinnerTable.AddColumn("[green]Country[/]");
                    CLLinnerTable.AddColumn("[green]Population[/]");
                    CLLinnerTable.AddColumn("[green]Noisy Pollution Level[/]");

                    if (CLLresult != null)
                    {
                        foreach (var city in CLLresult)
                        {
                            CLLinnerTable.AddRow(
                            city.Id.ToString() + "\n",
                            city.Name + "\n",
                            city.Country + "\n",
                            city.Population.ToString() + "\n",
                            city.NoisyPollutionLevel.ToString() + "\n"
                            );
                        }
                    }
                    else
                    {
                        CLLinnerTable.AddRow("Empty", "Empty", "Empty", "Empty", "Empty");
                    }
                    AnsiConsole.Write(CLLinnerTable);
                    break;
                case "[red]Go back[/]":
                    Console.Clear();

                    return;
            }
        }
    }
}
