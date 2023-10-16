using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class LastTemperaturesViewModel
    {
        public LastTemperaturesViewModel(Weather[] lastTemperatures)
        {
            ConcatenatedTemperatures = string.Join("", lastTemperatures.Select((temp, index) =>
            {
                string temperatureString = temp.Temperature.Metric.Value.ToString();
                if ((index + 1) % 6 == 0 && index > 0 && index < lastTemperatures.Length - 1) // Dodaj nową linię co 6 elementów (oprócz pierwszego i ostatniego)
                {
                    return temperatureString + ",\n";
                }
                else if (index == lastTemperatures.Length - 1) // Ostatni element
                {
                    return temperatureString;
                }
                else
                {
                    return temperatureString + ", ";
                }
            }));
        }
        public string ConcatenatedTemperatures { get; set; }
    }
}
