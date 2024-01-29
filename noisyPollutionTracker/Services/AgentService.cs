using Newtonsoft.Json;
using noisyPollutionTracker.Interfaces;
using noisyPollutionTracker.models.AgentModel;
using noisyPollutionTracker.models.CityModels;

namespace noisyPollutionTracker.Services;

public class AgentService : IAgentService
{
    CityService cityService;
    public AgentService(CityService cityService)
    {
        this.cityService = cityService;
    }
    public bool AddDiscoveredCityToAgent(int agentId, int CityId)
    {
        var done = false;

        var content = File.ReadAllText(Constants.AGENTS_PATH);
        var Agents = JsonConvert.DeserializeObject<List<AgentModel>>(content);
        
        var city = cityService.GetById(CityId);
        if (city != null)
        {
            if (Agents != null)
            {
                foreach (var agent in Agents)
                {
                    if (agent.Id == agentId)
                    {
                        if (agent.DiscoveredCities == null)
                        {
                            agent.DiscoveredCities = new List<CityModel>();
                        }
                        agent.DiscoveredCities.Add(city);

                        var result = JsonConvert.SerializeObject(Agents, Formatting.Indented);
                        File.WriteAllText(Constants.AGENTS_PATH, result);
                        done = true;

                        break;
                    }
                }
            }
        }
        return done;
    }

    public AgentViewModel Create(AgentModel agent)
    {
        var content = File.ReadAllText(Constants.AGENTS_PATH);
        var Agents = JsonConvert.DeserializeObject<List<AgentModel>>(content);
        if (Agents == null)
        {
            Agents = new List<AgentModel>();
        }
        
        agent.Id = Agents.Count+1;
        agent.DiscoveredCities = new List<CityModel>();
        
        Agents.Add(agent);

        AgentViewModel res = new AgentViewModel();
        res.Id = agent.Id;
        res.Firstname = agent.Firstname;
        res.Lastname = agent.Lastname;

        var result = JsonConvert.SerializeObject(Agents, Formatting.Indented);
        File.WriteAllText(Constants.AGENTS_PATH, result);
        return res;
    }
    public bool Delete(int id)
    {
        var content = File.ReadAllText(Constants.AGENTS_PATH);
        var Agents = JsonConvert.DeserializeObject<List<AgentModel>>(content);

        var found = false;
        foreach (var item in Agents)
        {
            if (item.Id == id)
            {

                Agents.Remove(item);
                found = true;
                break;
            }
        }
        if (found == true)
        {
            var result = JsonConvert.SerializeObject(Agents, Formatting.Indented);
            File.WriteAllText(Constants.AGENTS_PATH, result);
        }
        return found;
    }
    public AgentModel GetById(int id)
    {
        var content = File.ReadAllText(Constants.AGENTS_PATH);
        var Agents = JsonConvert.DeserializeObject<List<AgentModel>>(content);

        AgentModel found = null;
        foreach (var item in Agents)
        {
            if (item.Id == id)
            {
                found = item;
                break;
            } 
        }
        return found;
    }
    public List<CityModel> GetDiscoveredCities()
    {
        List<CityModel> discoveredCities = new List<CityModel>();
        var content = File.ReadAllText(Constants.AGENTS_PATH);
        var Agents = JsonConvert.DeserializeObject<List<AgentModel>>(content);

        foreach (var agent in Agents)
        {
            if (agent.DiscoveredCities != null)
            {
                foreach (var city in agent.DiscoveredCities)
                {
                
                        discoveredCities.Add(city);
                }
            }

        }
        return discoveredCities;
    }
    public (bool agentFound, bool cityFound) RemoveDiscoveredCityToAgent(int agentId, int CityId)
    {
        var content = File.ReadAllText(Constants.AGENTS_PATH);
        var Agents = JsonConvert.DeserializeObject<List<AgentModel>>(content);

        var agentFound = false;
        var cityFound = false;
        foreach (var agent in Agents)
        {
            if (agent.Id == agentId)
            {
                foreach (var city in agent.DiscoveredCities)
                {
                    if (city.Id == CityId)
                    {
                        agent.DiscoveredCities.Remove(city);
                        cityFound = true;
                        break;
                    }
                }
                agentFound = true;
                break;
            }
        }
        if (agentFound == true && cityFound == true) 
        {
            var result = JsonConvert.SerializeObject(Agents, Formatting.Indented);
            File.WriteAllText(Constants.AGENTS_PATH, result);
        }
        return (agentFound, cityFound);
    }
    public AgentViewModel Update(int id, AgentViewModel agent)
    {
        var content = File.ReadAllText(Constants.AGENTS_PATH);
        var Agents = JsonConvert.DeserializeObject<List<AgentModel>>(content);

        AgentViewModel found = null;
        foreach (var item in Agents)
        {
            if (item.Id == id)
            {
                item.Firstname = agent.Firstname;
                item.Lastname = agent.Lastname;

                found = new AgentViewModel();
                found.Id = item.Id;
                found.Firstname = item.Firstname;
                found.Lastname = item.Lastname;

                break;
            }
        }
        if (found != null)
        {
            var result = JsonConvert.SerializeObject(Agents, Formatting.Indented);
            File.WriteAllText(Constants.AGENTS_PATH, result);
        }
        return found;
    }
}
