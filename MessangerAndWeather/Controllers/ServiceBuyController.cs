using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessangerAndWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBuyController : ControllerBase
    {
        private readonly IGenericService<SERVICEBUY> _genericService;
        public ServiceBuyController(IGenericService<SERVICEBUY> genericService)
        {
           _genericService = genericService;
        }

        // https://localhost:44372/api/SERVICEBUY [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<SERVICEBUY>>("GETALL",null));
        }

        // https://localhost:44372/api/SERVICEBUY/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] SERVICEBUY serviceBuy)
        {
            return Ok(await _genericService.GenericCRUD<SERVICEBUY>("GETBYID", serviceBuy));
        }


        //https://localhost:44372/api/SERVICEBUY   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] SERVICEBUY serviceBuy)
        {
            var exi = await _genericService.GenericCRUD<SERVICEBUY>("GETBYNAME", serviceBuy);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", serviceBuy));
        }

        //https://localhost:44372/api/SERVICEBUY   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SERVICEBUY serviceBuy)
        {
            var exi = await _genericService.GenericCRUD<SERVICEBUY>("GETBYNAME", serviceBuy);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", serviceBuy));
        }

        //https://localhost:44372/api/SERVICEBUY   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] SERVICEBUY serviceBuy)
        {
            var exi = await _genericService.GenericCRUD<SERVICEBUY>("GETBYID", serviceBuy);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", serviceBuy));
        }
    }
}
