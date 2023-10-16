using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Commands;
using P04WeatherForecastAPI.Client.DataSeeders;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class MainViewModelV4 : ObservableObject
    {
        private CityViewModel _selectedCity;
        private Weather _weather;
        private Forecast _oneDayForecast;
        private Forecast _fiveDayForecast;
        private City[] _cityNeighbors;
        private Weather[] _lastTemperatures;
        private City _selectedCityTmp;
        private readonly IAccuWeatherService _accuWeatherService;
        private readonly FavoriteCitiesView _favoriteCitiesView;
        private readonly FavoriteCityViewModel _favoriteCityViewModel;

        public MainViewModelV4(IAccuWeatherService accuWeatherService, FavoriteCityViewModel favoriteCityViewModel, FavoriteCitiesView favoriteCitiesView)
        {
            _favoriteCitiesView = favoriteCitiesView;
            _favoriteCityViewModel = favoriteCityViewModel;
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); // podejście nr 2 
        }

        [ObservableProperty]
        private WeatherViewModel weatherView;

        [ObservableProperty]
        private OneDayForecastViewModel oneDayForecastView;

        [ObservableProperty]
        private FiveDayForecastViewModel fiveDayForecastView;

        [ObservableProperty]
        private CityNeighborsViewModel cityNeighborsView;

        [ObservableProperty]
        private LastTemperaturesViewModel lastTemperaturesView;

        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
                LoadNeighbors();
                LoadLastTemperatures();
            }
        }
         
        private async void LoadWeather()
        {
            if(SelectedCity != null)
            {
                _weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key);
                WeatherView = new WeatherViewModel(_weather);
                _oneDayForecast = await _accuWeatherService.GetOneDayOfDailyForecast(SelectedCity.Key);
                OneDayForecastView = new OneDayForecastViewModel(_oneDayForecast);
                _fiveDayForecast = await _accuWeatherService.GetFiveDaysOfDailyForecast(SelectedCity.Key);
                FiveDayForecastView = new FiveDayForecastViewModel(_fiveDayForecast);
            }
        }

        private async void LoadNeighbors()
        {
            if (SelectedCity != null)
            {
                _cityNeighbors = await _accuWeatherService.GetCityNeighbors(SelectedCity.Key);
                CityNeighborsView = new CityNeighborsViewModel(_cityNeighbors);
            }
        }
        private async void LoadLastTemperatures()
        {
            if (SelectedCity != null)
            {
                _lastTemperatures = await _accuWeatherService.GetLastTemperatures(SelectedCity.Key);
                LastTemperaturesView = new LastTemperaturesViewModel(_lastTemperatures);
            }
        }

        // podajście nr 2 do przechowywania kolekcji obiektów:
        public ObservableCollection<CityViewModel> Cities { get; set; }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities) 
                Cities.Add(new CityViewModel(city));
        }

        [RelayCommand]
        public async void LoadPostalCode(string postalCode)
        {
            var postalCodes = await _accuWeatherService.GetLocationsPostalCode(postalCode);
            var selectedPostalCode = postalCodes.FirstOrDefault();
            var cityName = selectedPostalCode.LocalizedName;
            City[] cities = await _accuWeatherService.GetLocations(cityName);
            _selectedCityTmp = cities.FirstOrDefault();
            SelectedCity = new CityViewModel(_selectedCityTmp);
        }

        [RelayCommand]
        public void OpenFavouriteCities()
        {
            _favoriteCityViewModel.SelectedCity = new FavoriteCity() { Name = "Warsaw" };
            _favoriteCitiesView.Show();
        }
    }
}
