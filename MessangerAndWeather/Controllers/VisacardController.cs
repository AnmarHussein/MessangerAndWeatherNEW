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
    public class VisacardController : ControllerBase
    {
        private readonly IGenericService<VISACARD> _genericService;
        public VisacardController( IGenericService<VISACARD> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/VISACARD [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<VISACARD>>("GETALL",null));
        }

        // https://localhost:44372/api/VISACARD/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] VISACARD visa)
        {
            return Ok(await _genericService.GenericCRUD<VISACARD>("GETBYID", visa));
        }


        //https://localhost:44372/api/VISACARD   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] VISACARD visa)
        {
            var exi = await _genericService.GenericCRUD<VISACARD>("GETBYCARDNUMBER", visa);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", visa));
        }

        //https://localhost:44372/api/VISACARD   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VISACARD visa)
        {
            var exi = await _genericService.GenericCRUD<VISACARD>("GETBYCARDNUMBER", visa);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", visa));
        }

        //https://localhost:44372/api/VISACARD   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] VISACARD visa)
        {
            var exi = await _genericService.GenericCRUD<VISACARD>("GETBYID", visa);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", visa));
        }
    }
}
