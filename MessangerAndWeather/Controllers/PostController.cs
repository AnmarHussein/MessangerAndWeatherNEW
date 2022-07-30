using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MessangerAndWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IGenericService<POST> _genericService;
        public PostController(IGenericService<POST> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/Post [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<POST>>("GETALL" ,null));
        }

        // https://localhost:44372/api/Post/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] POST post)
        {
            return Ok(await _genericService.GenericCRUD<POST>("GETBYID", post));
        }


        //https://localhost:44372/api/Post   [POST]

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] POST post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", post));
        }

        //https://localhost:44372/api/Post   [PUT]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] POST post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", post));
        }

        //https://localhost:44372/api/Post   [Delete]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] POST post)
        {
            var exi = await _genericService.GenericCRUD<POST>("GETBYID", post);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", post));
        }
    }
}
