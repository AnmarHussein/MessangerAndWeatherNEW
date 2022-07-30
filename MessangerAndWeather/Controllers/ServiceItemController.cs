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
    public class ServiceItemController : ControllerBase
    {
        private readonly IGenericService<SERVICEITEM> _genericService;
        public ServiceItemController( IGenericService<SERVICEITEM> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/SERVICEITEM [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<SERVICEITEM>>("GETALL" ,null));
        }

        // https://localhost:44372/api/SERVICEITEM/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] SERVICEITEM serviceItem)
        {
            return Ok(await _genericService.GenericCRUD<SERVICEITEM>("GETBYID", serviceItem));
        }


        //https://localhost:44372/api/SERVICEBUY   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] SERVICEITEM serviceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", serviceItem));
        }

        //https://localhost:44372/api/SERVICEBUY   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SERVICEITEM serviceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", serviceItem));
        }

        //https://localhost:44372/api/SERVICEBUY   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] SERVICEITEM serviceItem)
        {
            var exi = await _genericService.GenericCRUD<SERVICEITEM>("GETBYID", serviceItem);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", serviceItem)); ;
        }
    }
}
