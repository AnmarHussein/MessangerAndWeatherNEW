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
    public class FriendController : ControllerBase
    {
        private readonly IGenericService<FRIEND> _genericService;
        public FriendController(IGenericService<FRIEND> genericService )
        {
            _genericService = genericService;
        }
        // https://localhost:44372/api/FRIEND [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<FRIEND>>("GETALL" ,null));
        }

        // https://localhost:44372/api/FRIEND/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] FRIEND friend)
        {
            return Ok(await _genericService.GenericCRUD<FRIEND>("GETBYID", friend));
        }


        //https://localhost:44372/api/FRIEND   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] FRIEND friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", friend));
        }

        //https://localhost:44372/api/FRIEND   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FRIEND friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", friend));
        }

        //https://localhost:44372/api/FRIEND   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] FRIEND friend)
        {
            var exi = await _genericService.GenericCRUD<FRIEND>("GETBYID", friend);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", friend));
        }
    }
}
