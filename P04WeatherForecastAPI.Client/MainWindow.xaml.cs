using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccuWeatherService accuWeatherService;
        public MainWindow()
        {
            InitializeComponent();
            accuWeatherService = new AccuWeatherService();
        }

        private async void btnSearchCity_Click(object sender, RoutedEventArgs e)
        {
            
            City[] cities= await accuWeatherService.GetLocationsPl(txtCity.Text);
            // standardowy sposób dodawania elementów
            //lbData.Items.Clear();
            //foreach (var c in cities)
            //    lbData.Items.Add(c.LocalizedName);
            // teraz musimy skorzystac z bindowania danych bo chcemy w naszej kontrolce przechowywac takze id miasta 
            lbData.ItemsSource = cities;
        }

        private async void btnSearchPostalCode_Click(object sender, RoutedEventArgs e)
        {
            PostalCode[] postalCodes = await accuWeatherService.GetLocationsPostalCode(txtPostalCode.Text);
            var selectedPostalCode = postalCodes.FirstOrDefault();
            var cityName = selectedPostalCode.LocalizedName;
            City[] cities = await accuWeatherService.GetLocationsPl(cityName);
            var selectedCity = cities.FirstOrDefault();
            if (selectedCity != null)
            {
                update(selectedCity);
            }
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity= (City)lbData.SelectedItem;
            if(selectedCity != null)
            {
                update(selectedCity);
            }
        }

        private async void update(City selectedCity)
        {
            lblCityName.Content = selectedCity.LocalizedName;

            var weather = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
            double tempValue = weather.Temperature.Metric.Value;
            lblTemperatureValue.Content = Convert.ToString(tempValue);

            var onedayforecast = await accuWeatherService.GetOneDayOfDailyForecast(selectedCity.Key);
            double tempValueOneDayMin = onedayforecast.DailyForecasts[0].Temperature.Minimum.Value;
            double tempValueOneDayMax = onedayforecast.DailyForecasts[0].Temperature.Maximum.Value;
            lblTemperatureValueOneDayMin.Content = Convert.ToString(tempValueOneDayMin);
            lblTemperatureValueOneDayMax.Content = Convert.ToString(tempValueOneDayMax);

            var fivedaysforecast = await accuWeatherService.GetFiveDaysOfDailyForecast(selectedCity.Key);
            double tempValueFiveDaysMin = fivedaysforecast.DailyForecasts[4].Temperature.Minimum.Value;
            double tempValueFiveDaysMax = fivedaysforecast.DailyForecasts[4].Temperature.Maximum.Value;
            lblTemperatureValueFiveDaysMin.Content = Convert.ToString(tempValueFiveDaysMin);
            lblTemperatureValueFiveDaysMax.Content = Convert.ToString(tempValueFiveDaysMax);

            City[] cityneighbors = await accuWeatherService.GetCityNeighbors(selectedCity.Key);
            string concatenatedNames = string.Join("\n", cityneighbors.Select(city => city.LocalizedName));
            lblCityNeighbors.Content = Convert.ToString(concatenatedNames);

            Weather[] lasttemperatures = await accuWeatherService.GetLastTemperatures(selectedCity.Key);
            string concatenatedTemperatures = string.Join("", lasttemperatures.Select((temp, index) =>
            {
                string temperatureString = temp.Temperature.Metric.Value.ToString();
                if ((index + 1) % 6 == 0 && index > 0 && index < lasttemperatures.Length - 1) // Dodaj nową linię co 6 elementów (oprócz pierwszego i ostatniego)
                {
                    return temperatureString + ",\n";
                }
                else if (index == lasttemperatures.Length - 1) // Ostatni element
                {
                    return temperatureString;
                }
                else
                {
                    return temperatureString + ", ";
                }
            }));
            lblLastTemperatures.Content = Convert.ToString(concatenatedTemperatures);
        }
    }
}
