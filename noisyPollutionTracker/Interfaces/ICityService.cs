using noisyPollutionTracker.models.CityModels;

namespace noisyPollutionTracker.Interfaces;

public interface ICityService
{
    CityModel GetById(int id);
    CityViewModel GetByCityName(string cityName);
    List<CityViewModel> GetCitiesByCountry(string countryName);
    List<CityViewModel> GetAllHighLevel();
    List<CityViewModel> GetAllModerateLevel();
    List<CityViewModel> GetAllLowLevel();
    CityModel GetCityWithNeighourhoodCities(string cityName);
}
