using MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVVM.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string API_KEY = "mLUbG3hmcqhyz9ARaH55RYXvpo3p2vNG";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<CityInfo>> GetCities(string query)
        {
            var cities = new List<CityInfo>();

            var url = BASE_URL + String.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            using (var client = new HttpClient())
            {
                var responce = await client.GetAsync(url);
                var json = await responce.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<CityInfo>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string locationKey)
        {
            var currentConditions = new CurrentConditions();

            var url = BASE_URL + String.Format(CURRENT_CONDITIONS_ENDPOINT, locationKey, API_KEY);

            using (var client = new HttpClient())
            {
                var responce = await client.GetAsync(url);
                var json = await responce.Content.ReadAsStringAsync();

                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
            }

            return currentConditions;
        }
    }
}
