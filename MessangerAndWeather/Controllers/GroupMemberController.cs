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
    public class GroupMemberController : ControllerBase
    {
        private readonly IGenericService<GROUPMEMBER> _genericService;
        public GroupMemberController(IGenericService<GROUPMEMBER> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/CATEGORY [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<GROUPMEMBER>>("GETALL", null));
        }

        // https://localhost:44372/api/CATEGORY/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] GROUPMEMBER groupMember)
        {
            return Ok(await _genericService.GenericCRUD<GROUPMEMBER>("GETBYID", groupMember));
        }


        //https://localhost:44372/api/CATEGORY   [POST]

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] GROUPMEMBER groupMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", groupMember));
        }

        //https://localhost:44372/api/CATEGORY   [PUT]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GROUPMEMBER groupMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _genericService.GenericCRUD<string>("UPDATE", groupMember));
        }

        //https://localhost:44372/api/CATEGORY   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] GROUPMEMBER groupMember)
        {
            var exi = await _genericService.GenericCRUD<GROUPMEMBER>("GETBYID", groupMember);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", groupMember));
        }
    }
}
