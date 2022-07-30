using Core.DTO.openweathermap_Model;
using Core.Service;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace infra.Service
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private string APIKEY { get; set; }
        private readonly IConfiguration _configuration;
        public WeatherForecastService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public WeatherResponse GetWetherForCity(string city)
        {
            
            try
            {
                APIKEY = _configuration["OpenWeatherMap:APIKEY"];
                var path = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={APIKEY}&units=metric";
                using (WebClient client = new WebClient())
                {
                    var content = client.DownloadString(path);
                    return JsonConvert.DeserializeObject<WeatherResponse>(content);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }
    }
}
