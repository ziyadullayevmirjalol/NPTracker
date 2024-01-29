using noisyPollutionTracker.models.AgentModel;
using noisyPollutionTracker.models.CityModels;
using noisyPollutionTracker.Services;
using Spectre.Console;

namespace noisyPollutionTracker.ConsoleUI.SubMenus;

public class AgentMenu
{
    private AgentService agentService;

    public AgentMenu(AgentService agentService)
    {
        this.agentService = agentService;
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
                        "Register new agent",
                        "Update agent's details",
                        "Delete agent",
                        "Get agent by ID",
                        "Add agent's discovered city",
                        "Remove agent's discovered city",
                        "Get all agent's discovered cities\n",
                        "[red]Go back[/]"}));
            switch (choise)
            {
                case "Register new agent":
                    Console.Clear();

                    var Cfirstname = AnsiConsole.Ask<string>("Enter your [green]Firstname[/]:");
                    var Clastname = AnsiConsole.Ask<string>("Enter your [green]Lastname[/]:");

                    AgentModel newAgent = new AgentModel();
                    newAgent.Firstname = Cfirstname;
                    newAgent.Lastname = Clastname;

                    AgentViewModel createdAgent = agentService.Create(newAgent);

                    if (createdAgent != null)
                    {
                        var table = new Table();

                        table.AddColumn("Created new agent!");

                        table.AddRow($"[green]Agent's ID[/]: {createdAgent.Id}");
                        table.AddRow($"[green]Agent's Firstname[/]: {createdAgent.Firstname}");
                        table.AddRow($"[green]Agent's Firstname[/]: {createdAgent.Lastname}");

                        AnsiConsole.Write(table);
                    } else
                    {
                        AnsiConsole.Write("Maybe you did something wrong or you're not able to create agent now");
                    }
                    break;
                case "Update agent's details":
                    Console.Clear();

                    var Uid = AnsiConsole.Ask<int>("Enter your [green]ID[/]:");
                    var Ufirstname = AnsiConsole.Ask<string>("Enter your [green]Firstname[/]:");
                    var Ulastname = AnsiConsole.Ask<string>("Enter your [green]Lastname[/]:");

                    AgentViewModel UpdateAgent = new AgentViewModel();
                    UpdateAgent.Id = Uid;
                    UpdateAgent.Firstname = Ufirstname;
                    UpdateAgent.Lastname = Ulastname;

                    AgentViewModel updatedAgent = agentService.Update(Uid, UpdateAgent);

                    if (updatedAgent!= null)
                    {
                        var table1 = new Table();

                        table1.AddColumn("Updated Agent");

                        table1.AddRow($"[green]Agent's ID[/]: {updatedAgent.Id}");
                        table1.AddRow($"[green]Agent's Firstname[/]: {UpdateAgent.Firstname}");
                        table1.AddRow($"[green]Agnet's Lastname[/]: {updatedAgent.Lastname}");

                        AnsiConsole.Write(table1);
                    }
                    else
                    {
                        var tablee = new Table();
                        tablee.AddColumn("Updated Agent");
                        tablee.AddRow($"[green]Agent with ID[/]: {Uid} not found");
                        AnsiConsole.Write(tablee);
                    }
                    break;
                case "Delete agent":
                    Console.Clear();

                    var Did = AnsiConsole.Ask<int>("Enter your [green]ID[/]:");

                    bool deletedAgent = agentService.Delete(Did);
                    if (deletedAgent != false)
                    {
                        var table2 = new Table();
                        table2.AddColumn("Deleted Agent");
                        table2.AddRow($"[green]Agent's ID[/]: {Did} successfully deleted");
                        AnsiConsole.Write(table2);
                    }
                    else
                    {
                        var table3 = new Table();
                        table3.AddColumn("Deleted Agent");
                        table3.AddRow($"[green]Agent with ID[/]: {Did} not found");
                        AnsiConsole.Write(table3);
                    }

                    break;
                case "Get agent by ID":
                    Console.Clear();

                    var Gid = AnsiConsole.Ask<int>("Enter your [green]ID[/]:");

                    AgentModel gottenAgent = agentService.GetById(Gid);
                    if (gottenAgent != null)
                    {
                        var table4 = new Table();
                        table4.AddColumn("Found Agent");
                        table4.AddRow($"[green]UserID[/]: {gottenAgent.Id}");
                        table4.AddRow($"[green]User's Firstname[/]: {gottenAgent.Firstname}");
                        table4.AddRow($"[green]User's Lastname[/]: {gottenAgent.Lastname}");

                        var innerTable = new Table();

                        innerTable.AddColumn("[green]City ID[/]");
                        innerTable.AddColumn("[green]City Name[/]");
                        innerTable.AddColumn("[green]Country[/]");
                        innerTable.AddColumn("[green]Population[/]");
                        innerTable.AddColumn("[green]Noisy Pollution Level[/]");
                        innerTable.AddColumn("[green]Neighborhood Cities[/]");

                        if (gottenAgent.DiscoveredCities.Count != 0)
                        {
                            foreach (CityModel cityModel in gottenAgent.DiscoveredCities)
                            {
                                innerTable.AddRow(
                                    cityModel.Id.ToString()+ "\n",
                                    cityModel.Name + "\n",
                                    cityModel.Country + "\n",
                                    cityModel.Population.ToString() + "\n",
                                    cityModel.NoisyPollutionLevel.ToString() + "\n",
                                    cityModel.NeighbourhoodCities != null && cityModel.NeighbourhoodCities.Any() ?
                                        string.Join(", ", cityModel.NeighbourhoodCities)+"\n" :
                                        "No neighborhood cities found."
                                );
                            }
                        }
                        else
                        {
                            innerTable.AddRow("Empty", "Empty", "Empty", "Empty", "Empty", "Empty");
                        }

                        AnsiConsole.Write(table4);
                        AnsiConsole.Write(innerTable);
                    }
                    else
                    {
                        var table5 = new Table();
                        table5.AddColumn("Found Agent");
                        table5.AddRow($"[green]Agent with ID[/]: {Gid} not found");
                        AnsiConsole.Write(table5);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                case "Add agent's discovered city":
                    Console.Clear();
                    var Aid = AnsiConsole.Ask<int>("Enter Agent's [green]ID[/]:");
                    var Cid = AnsiConsole.Ask<int>("Enter City's [green]ID[/]:");

                    var result = agentService.AddDiscoveredCityToAgent(Aid, Cid);
                    if (result != false)
                    {
                        AnsiConsole.Write("\nSuccesssfully added.\n");
                    }
                    else
                    {
                        AnsiConsole.Write("\nAaugh, you did something wrong, try again!\n");
                    }

                    break;
                case "Remove agent's discovered city":
                    Console.Clear();
                    var rAid = AnsiConsole.Ask<int>("Enter Agent's [green]ID[/]:");
                    var rCid = AnsiConsole.Ask<int>("Enter City's [green]ID[/]:");

                    var (agenffound, cityfound) = agentService.RemoveDiscoveredCityToAgent(rAid, rCid);
                    if (agenffound == true && cityfound == true)
                    {
                        AnsiConsole.Write("\nSuccessfully removed\n");
                    }
                    else
                    {
                        AnsiConsole.Write("\nAaugh, you did something wrong, try again!\n");
                    }

                    break;
                case "Get all agent's discovered cities\n":
                    Console.Clear();
                    var DiscoveredCities = agentService.GetDiscoveredCities();
                    var innerTablee = new Table();
                    innerTablee.AddColumn("[green]Discovered Cities[/]");

                    if (DiscoveredCities != null && DiscoveredCities.Count > 0)
                    {
                        foreach (CityModel cityModel in DiscoveredCities)
                        {
                            innerTablee.AddRow("------------------------------------");
                            innerTablee.AddRow($"City ID: {cityModel.Id}");
                            innerTablee.AddRow($"City Name: {cityModel.Name}");
                            innerTablee.AddRow($"City's Country: {cityModel.Country}");
                            innerTablee.AddRow($"City's population: {cityModel.Population}");
                            innerTablee.AddRow($"City's Noisy Pollution Level: {cityModel.NoisyPollutionLevel}");

                            var neighbourhoodInnerTable = new Table();
                            neighbourhoodInnerTable.AddColumn("[green]Neighbourhood Cities[/]");

                            if (cityModel.NeighbourhoodCities != null && cityModel.NeighbourhoodCities.Count > 0)
                            {
                                foreach (string city in cityModel.NeighbourhoodCities)
                                {
                                    neighbourhoodInnerTable.AddRow(city);
                                }
                            }
                            else
                            {
                                neighbourhoodInnerTable.AddRow("Empty");
                            }

                            innerTablee.AddRow(neighbourhoodInnerTable);
                            innerTablee.AddRow("------------------------------------");
                        }
                    }
                    else
                    {
                        innerTablee.AddRow("Empty");
                    }
                    AnsiConsole.Write(innerTablee);
                    break;
                case "[red]Go back[/]":
                    Console.Clear();
                    return;
            }
        }
    }
}
