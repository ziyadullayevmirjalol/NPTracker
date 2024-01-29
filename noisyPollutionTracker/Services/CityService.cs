using noisyPollutionTracker.Interfaces;
using noisyPollutionTracker.models.CityModels;

namespace noisyPollutionTracker.Services;

public class CityService : ICityService
{
    private readonly List<CityModel> citylist;

    public CityService(List<CityModel> citylist)
    {
        this.citylist = citylist;
    }

    public List<CityViewModel> GetAllHighLevel()
    {
        List<CityViewModel> cities = new List<CityViewModel>();
        foreach (var city in citylist)
        {
            if (city.NoisyPollutionLevel == "High")
            {
                CityViewModel cityViewModel = new CityViewModel();
                cityViewModel.Id = city.Id;
                cityViewModel.Name = city.Name;
                cityViewModel.NoisyPollutionLevel = city.NoisyPollutionLevel;
                cityViewModel.Population = city.Population;

                cities.Add(cityViewModel);
            }
        }
        return cities;
    }
    public List<CityViewModel> GetAllLowLevel()
    {
        List<CityViewModel> cities = new List<CityViewModel>();
        foreach (var city in citylist)
        {
            if (city.NoisyPollutionLevel == "Low")
            {
                CityViewModel cityViewModel = new CityViewModel();
                cityViewModel.Id = city.Id;
                cityViewModel.Name = city.Name;
                cityViewModel.NoisyPollutionLevel = city.NoisyPollutionLevel;
                cityViewModel.Population = city.Population;

                cities.Add(cityViewModel);
            }
        }
        return cities;
    }
    public List<CityViewModel> GetAllModerateLevel()
    {
        List<CityViewModel> cities = new List<CityViewModel>();
        foreach (var city in citylist)
        {
            if (city.NoisyPollutionLevel == "Moderate")
            {
                CityViewModel cityViewModel = new CityViewModel();
                cityViewModel.Id = city.Id;
                cityViewModel.Name = city.Name;
                cityViewModel.NoisyPollutionLevel = city.NoisyPollutionLevel;
                cityViewModel.Population = city.Population;

                cities.Add(cityViewModel);
            }
        }
        return cities;
    }
    public CityViewModel GetByCityName(string cityName)
    {
        CityViewModel cityViewModel = null;

        foreach (var city in citylist)
        {
            if (city.Name == cityName)
            {
                cityViewModel = new CityViewModel();
                cityViewModel.Id = city.Id;
                cityViewModel.Name = city.Name;
                cityViewModel.NoisyPollutionLevel = city.NoisyPollutionLevel;
                cityViewModel.Population = city.Population;
                break;
            }
        }
        return cityViewModel;
    }
    public CityModel GetById(int id)
    {
        CityModel cityModel = null;

        foreach (var city in citylist)
        {
            if (city.Id == id)
            {
                cityModel = new CityModel();
                cityModel = city;
                break;
            }
        }
        return cityModel;
    }
    public List<CityViewModel> GetCitiesByCountry(string countryName)
    {
        List<CityViewModel> cities = new List<CityViewModel>();
        foreach (var city in citylist)
        {
            if (city.Country == countryName)
            {
                CityViewModel cityViewModel = new CityViewModel();
                cityViewModel.Id = city.Id;
                cityViewModel.Name = city.Name;
                cityViewModel.Country = city.Country;
                cityViewModel.NoisyPollutionLevel = city.NoisyPollutionLevel;
                cityViewModel.Population = city.Population;

                cities.Add(cityViewModel);
            }
        }
        return cities;
    }
    public CityModel GetCityWithNeighourhoodCities(string cityName)
    {
        CityModel cityModel = null;

        foreach (var city in citylist)
        {
            if (city.Name == cityName)
            {
                cityModel = new CityModel();
                cityModel = city;
                break;
            }
        }
        return cityModel;
    }
}
