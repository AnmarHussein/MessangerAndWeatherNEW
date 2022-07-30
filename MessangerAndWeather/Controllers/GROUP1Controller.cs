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
    public class GROUP1Controller : ControllerBase
    {
        private readonly IGenericService<GROUP1> _genericService;
        public GROUP1Controller(IGenericService<GROUP1> genericService)
        {
            _genericService = genericService;
        }


        // https://localhost:44372/api/GROUP1 [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<GROUP1>>("GETALL", null));
        }

        // https://localhost:44372/api/GROUP1/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] GROUP1 group)
        {
            return Ok(await _genericService.GenericCRUD<GROUP1>("GETBYID", group));
        }


        //https://localhost:44372/api/GROUP1   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] GROUP1 group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", group));
        }

        //https://localhost:44372/api/GROUP1   [PUT]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GROUP1 group)
        {
            if (!ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", group));
        }

        //https://localhost:44372/api/GROUP1   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] GROUP1 group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", group));
        }
    }
}
