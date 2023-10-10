using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class AccuWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string postal_code_endpoint = "locations/v1/postalcodes/search?apikey={0}&q={1}&language{2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language{2}";
        private const string one_day_of_daily_forecasts_endpoint = "forecasts/v1/daily/1day/{0}?apikey={1}&language{2}";
        private const string five_days_of_daily_forecasts_endpoint = "forecasts/v1/daily/5day/{0}?apikey={1}&language{2}";
        private const string city_neighbors_endpoint = "locations/v1/cities/neighbors/{0}?apikey={1}&language{2}";
        private const string last_temperatures_endpoint = "currentconditions/v1/{0}/historical/24?apikey={1}&language{2}";

        private const string radar_and_satellite_imagery = "imagery/v1/maps/radsat/480x480/";

        // private const string api_key = "M4f5zGoGrDlcsILkI5472fVHp5YREIzz";
        string api_key;
        //private const string language = "pl";
        string language;

        public AccuWeatherService()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json"); 
                
            var configuration = builder.Build();
            api_key = configuration["api_key"];
            language = configuration["default_language"];
        }


        public async Task<City[]> GetLocations(string locationName)
        {
            string uri1_1 = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri1_1);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }

        public async Task<City[]> GetLocationsPostalCode(string locationName)
        {
            string uri1_2 = base_url + "/" + string.Format(postal_code_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri1_2);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri2 = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key,language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri2);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers= JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }

        public async Task<Forecast> GetOneDayOfDailyForecast(string cityKey)
        {
            string uri3 = base_url + "/" + string.Format(one_day_of_daily_forecasts_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri3);
                string json = await response.Content.ReadAsStringAsync();
                Forecast forecast = JsonConvert.DeserializeObject<Forecast>(json);
                return forecast;
            }
        }

        public async Task<Forecast> GetFiveDaysOfDailyForecast(string cityKey)
        {
            string uri4 = base_url + "/" + string.Format(five_days_of_daily_forecasts_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri4);
                string json = await response.Content.ReadAsStringAsync();
                Forecast forecast = JsonConvert.DeserializeObject<Forecast>(json);
                return forecast;
            }
        }

        public async Task<City[]> GetCityNeighbors(string cityKey)
        {
            string uri5 = base_url + "/" + string.Format(city_neighbors_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri5);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }

        public async Task<Weather[]> GetLastTemperatures(string cityKey)
        {
            string uri6 = base_url + "/" + string.Format(last_temperatures_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri6);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers = JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers;
            }
        }
    }
}
