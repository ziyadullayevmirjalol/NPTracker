using Newtonsoft.Json;

namespace noisyPollutionTracker.models.AgentModel;

public class AgentViewModel
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("firstname")]
    public string Firstname { get; set; }
    [JsonProperty("lastname")]
    public string Lastname { get; set; }
}
