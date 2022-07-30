using Core.DTO.openweathermap_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IWeatherForecastService
    {
        public WeatherResponse GetWetherForCity(string city);
    }
}
