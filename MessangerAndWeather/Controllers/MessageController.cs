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
    public class MessageController : ControllerBase
    {
        private readonly IGenericService<MESSAGE> _genericService;
        public MessageController(IGenericService<MESSAGE> genericService)
        {
            _genericService = genericService;
        }


        // https://localhost:44372/api/MESSAGE [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<MESSAGE>>("GETALL", null));
        }

        // https://localhost:44372/api/MESSAGE/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] MESSAGE message)
        {
            return Ok(await _genericService.GenericCRUD<MESSAGE>("GETBYID", message));
        }


        //https://localhost:44372/api/MESSAGE   [POST]

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] MESSAGE message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", message));
        }

        //https://localhost:44372/api/MESSAGE   [PUT]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MESSAGE message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", message));
        }

        //https://localhost:44372/api/MESSAGE   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] MESSAGE message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", message));
        }
    }
}
