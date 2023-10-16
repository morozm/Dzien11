using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class CityNeighborsViewModel
    {
        public CityNeighborsViewModel(City[] cities)
        {
            ConcatenatedNames = string.Join("\n", cities.Select(city => city.LocalizedName));
        }
        public string ConcatenatedNames { get; set; }
    }
}
