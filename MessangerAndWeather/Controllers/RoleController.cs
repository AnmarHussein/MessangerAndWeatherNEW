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
    public class RoleController : ControllerBase
    {
        private readonly IGenericService<ROLE> _genericService;
        public RoleController(IGenericService<ROLE> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/Role [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<ROLE>>("GETALL" ,null));
        }

        // https://localhost:44372/api/Role/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] ROLE role)
        {
            return Ok(await _genericService.GenericCRUD<ROLE>("GETBYID", role));
        }


        //https://localhost:44372/api/Role   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ROLE role)
        {
            var exi = await _genericService.GenericCRUD<ROLE>("GETBYNAME", role);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", role));
        }

        //https://localhost:44372/api/Role   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ROLE role)
        {
            var exi = await _genericService.GenericCRUD<ROLE>("GETBYNAME", role);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", role));
        }

        //https://localhost:44372/api/Role   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ROLE role)
        {
            var exi = await _genericService.GenericCRUD<ROLE>("GETBYID", role);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", role));
        }

    }
}
