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
    public class Like1Controller : ControllerBase
    {
        private readonly IGenericService<LIKE1> _genericService;
        public Like1Controller(IGenericService<LIKE1> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/Like1 [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<LIKE1>>("GETALL" ,null));
        }

        // https://localhost:44372/api/Like1/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] LIKE1 like)
        {
            return Ok(await _genericService.GenericCRUD<LIKE1>("GETBYID", like));
        }


        //https://localhost:44372/api/Post   [POST]

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] LIKE1 like)
        {
            var exi = await _genericService.GenericCRUD<LIKE1>("GETBYNAME", like);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", like));
        }

        //https://localhost:44372/api/Post   [PUT]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LIKE1 like)
        {
            var exi = await _genericService.GenericCRUD<LIKE1>("GETBYNAME", like);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", like));
        }

        //https://localhost:44372/api/Post   [Delete]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] LIKE1 like)
        {
            var exi = await _genericService.GenericCRUD<LIKE1>("GETBYID", like);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", like));
        }
    }
}
