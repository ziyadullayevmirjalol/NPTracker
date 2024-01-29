using Newtonsoft.Json;
using noisyPollutionTracker.models.CityModels;

namespace noisyPollutionTracker.Services.API;

public class CityAPI
{

    string CITIES_URL = "https://noisypollutiontracker.onrender.com";

    private HttpClient httpClientcities;
    private List<CityModel> cityList;

    public CityAPI()
    {
        cityList = new List<CityModel>();

        this.httpClientcities = new HttpClient();
        this.httpClientcities.BaseAddress = new Uri(CITIES_URL);
    }

    public async Task GetDataAsync()
    {
        var citiesResponse = await httpClientcities.GetAsync(CITIES_URL);
        var citiesData = await citiesResponse.Content.ReadAsStringAsync();

        cityList = JsonConvert.DeserializeObject<List<CityModel>>(citiesData);
    }

    public List<CityModel> GetCities()
    {
        return cityList;
    }
}
