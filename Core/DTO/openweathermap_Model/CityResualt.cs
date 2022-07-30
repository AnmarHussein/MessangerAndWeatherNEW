using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO.openweathermap_Model
{
    public class CityResualt
    {
        public string FullName { get; set; }
        public string cityname { get; set; }
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
    }
}
