using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO.openweathermap_Model
{
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
