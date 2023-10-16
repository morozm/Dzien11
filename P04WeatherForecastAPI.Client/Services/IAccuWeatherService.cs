using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public interface IAccuWeatherService
    {
        Task<City[]> GetLocations(string locationName);
        Task<PostalCode[]> GetLocationsPostalCode(string locationName);
        Task<Weather> GetCurrentConditions(string cityKey);
        Task<Forecast> GetOneDayOfDailyForecast(string cityKey);
        Task<Forecast> GetFiveDaysOfDailyForecast(string cityKey);
        Task<City[]> GetCityNeighbors(string cityKey);
        Task<Weather[]> GetLastTemperatures(string cityKey);
    }
}
