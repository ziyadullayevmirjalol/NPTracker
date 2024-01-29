using Newtonsoft.Json;

namespace noisyPollutionTracker.models.CityModels
{
    public class CityViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("population")]
        public double Population { get; set; }
        [JsonProperty("noisy_pollution_level")]
        public string NoisyPollutionLevel { get; set; }
    }
}
