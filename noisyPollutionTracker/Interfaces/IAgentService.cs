using noisyPollutionTracker.models.AgentModel;
using noisyPollutionTracker.models.CityModels;

namespace noisyPollutionTracker.Interfaces;

public interface IAgentService
{
    public AgentViewModel Create(AgentModel agent);
    public AgentViewModel Update(int id, AgentViewModel agent);
    public bool Delete(int id);
    public AgentModel GetById(int id);
    public bool AddDiscoveredCityToAgent(int agentId, int CityId);
    public (bool agentFound, bool cityFound) RemoveDiscoveredCityToAgent(int agentId, int CityId);
    public List<CityModel> GetDiscoveredCities();
}
