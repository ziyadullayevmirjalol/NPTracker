using Newtonsoft.Json;
using noisyPollutionTracker.models.CityModels;

namespace noisyPollutionTracker.models.AgentModel;

public class AgentModel
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("firstname")]
    public string Firstname { get; set; }
    [JsonProperty("lastname")]
    public string Lastname { get; set; }
    [JsonProperty("discovered_cities")]
    public List<CityModel> DiscoveredCities { get; set; }
}
