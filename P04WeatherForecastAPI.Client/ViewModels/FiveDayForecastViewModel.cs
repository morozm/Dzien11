using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class FiveDayForecastViewModel
    {
        public FiveDayForecastViewModel(Forecast forecast)
        {
            TempValueFiveDayMin = forecast.DailyForecasts[4].Temperature.Minimum.Value;
            TempValueFiveDayMax = forecast.DailyForecasts[4].Temperature.Maximum.Value;
        }
        public double TempValueFiveDayMin { get; set; }
        public double TempValueFiveDayMax { get; set; }
    }
}
