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
    public class CategoryController : ControllerBase
    {
        private readonly IGenericService<CATEGORY> _genericService;
        public CategoryController(IGenericService<CATEGORY> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/CATEGORY [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<CATEGORY>>("GETALL" ,null));
        }

        // https://localhost:44372/api/CATEGORY/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] CATEGORY cate)
        {
            return Ok(await _genericService.GenericCRUD<CATEGORY>("GETBYID", cate));
        }


        //https://localhost:44372/api/CATEGORY   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CATEGORY cate)
        {
            var exi = await _genericService.GenericCRUD<CATEGORY>("GETBYNAME", cate);
            if (!ModelState.IsValid  || exi != null)
            {
                return BadRequest(ModelState);  
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", cate));
        }

        //https://localhost:44372/api/CATEGORY   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CATEGORY cate)
        {
            var exi = await _genericService.GenericCRUD<CATEGORY>("GETBYNAME", cate);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", cate));
        }

        //https://localhost:44372/api/CATEGORY   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CATEGORY cate)
        {
            var exi = await _genericService.GenericCRUD<CATEGORY>("GETBYID", cate);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", cate));
        }
    }
}
