using MVVM.Helpers;
using MVVM.Model;
using MVVM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;
        private CurrentConditions currentConditions;
        public ObservableCollection<CityInfo> Cities { get; set; } = new ObservableCollection<CityInfo>();
        private CityInfo selectedCity;
        public SearchCommand SearchCommand { get; set; }

        public WeatherVM()
        {
            Query = "Rivne";
            SearchCommand = new SearchCommand(this);
        }

        public CityInfo SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                GetConditions();
                OnPropertyChanged();
            }
        }

        public CurrentConditions CurrentConditions
        {
            get => currentConditions;
            set
            {
                currentConditions = value;
                OnPropertyChanged();
            }
        }

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void GetCities()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
            Cities.Clear();
            foreach (var item in cities)
            {
                Cities.Add(item);
            }
        }

        private async void GetConditions()
        {
            if (SelectedCity != null)
            {
                CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
            }
            else
            {
                CurrentConditions = new CurrentConditions();
            }
        }
    }
}
