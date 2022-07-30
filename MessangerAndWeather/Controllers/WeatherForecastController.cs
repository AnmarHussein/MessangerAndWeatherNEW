using Core.Data;
using Core.DTO.openweathermap_Model;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangerAndWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IGenericService<USER1> _genericService;
        private readonly IOthersService _othersService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService, IGenericService<USER1> genericService , IOthersService othersService)
        {
            _weatherForecastService = weatherForecastService;
            _othersService = othersService;
            _genericService = genericService;
        }

        [HttpGet("GetCityWeatherByUser")]
        public async Task<IActionResult> GetCity([FromBody] USER1 user)
        {
            
            var customer = await _genericService.GenericCRUD<USER1>("GETBYID",user);
            if(customer == null)
                return NotFound();

            WeatherResponse weather = new WeatherResponse();
            CityResualt cityResualt = new CityResualt();
            weather = _weatherForecastService.GetWetherForCity(customer.City);
            if(weather != null)
            {
                cityResualt.FullName = customer.FullName;
                cityResualt.temp = weather.Main.temp;
                cityResualt.pressure = weather.Main.pressure;
                cityResualt.temp_min = weather.Main.temp_min;
                cityResualt.temp_max = weather.Main.temp_max;
                cityResualt.cityname = weather.name;
                return Ok(cityResualt);
            }
            
            return BadRequest();  
        }


        [HttpGet("GetAllCityWeather")]
        public IActionResult GetAllCityWeather()
        {

            var citys =  _othersService.GetCityNumberOfUser1().Result.Select(x=>x.CITY).ToArray();
            
            if (citys.Length < 1)
                return BadRequest();

            List<CityResualt> listCity = new List<CityResualt>();
            foreach (var city in citys)
            {
                WeatherResponse weather = new WeatherResponse();
                CityResualt cityResualt = new CityResualt();
                weather = _weatherForecastService.GetWetherForCity(city);
                if (weather != null)
                {
                    cityResualt.temp = weather.Main.temp;
                    cityResualt.pressure = weather.Main.pressure;
                    cityResualt.temp_min = weather.Main.temp_min;
                    cityResualt.temp_max = weather.Main.temp_max;
                    cityResualt.cityname = weather.name;

                }
                listCity.Add(cityResualt);
            }
            return Ok(listCity);
           
        }

    }
}
