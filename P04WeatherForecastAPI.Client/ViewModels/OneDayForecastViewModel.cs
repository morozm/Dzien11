using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class OneDayForecastViewModel
    {
        public OneDayForecastViewModel(Forecast forecast)
        {
            TempValueOneDayMin = forecast.DailyForecasts[0].Temperature.Minimum.Value;
            TempValueOneDayMax = forecast.DailyForecasts[0].Temperature.Maximum.Value;
        }
        public double TempValueOneDayMin { get; set; }
        public double TempValueOneDayMax { get; set; }
    }
}
