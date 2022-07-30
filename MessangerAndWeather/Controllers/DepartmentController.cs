using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace MessangerAndWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IGenericService<DEPARTMENT> _genericService;
        public DepartmentController(IGenericService<DEPARTMENT> genericService)
        {
            _genericService = genericService;
        }


        // https://localhost:44372/api/Department/ReadDataDepartmentInFile  [Post]
        // Form-data name = file  => Select The File Unites.txt
        [HttpPost("ReadDataDepartmentInFile")]
        public async Task<bool> ReadDataDepartmentInFile([FromForm] IFormFile file)
        {
            using (var str = new StreamReader(file.OpenReadStream()))
            {
                DEPARTMENT dept = new DEPARTMENT();
                string line = "";
                while ((line = str.ReadLine()) != null)
                { 
                    dept.NAME = line;
                    await Insert(dept);
                }
            }
            return true;
        }



        // https://localhost:44372/api/Department [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<DEPARTMENT>>("GETALL",null));
        }

        // https://localhost:44372/api/Department/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] DEPARTMENT dept)
        {
            return Ok(await _genericService.GenericCRUD<DEPARTMENT>("GETBYID",dept));
        }


        //https://localhost:44372/api/Department   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DEPARTMENT dept )
        {
            var exi = await _genericService.GenericCRUD<DEPARTMENT>("GETBYNAME", dept);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", dept));
        }

        //https://localhost:44372/api/Department   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DEPARTMENT dept)
        {
            var exi = await _genericService.GenericCRUD<DEPARTMENT>("GETBYNAME", dept);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", dept));
        }

        //https://localhost:44372/api/Department   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DEPARTMENT dept)
        {
            var exi = await _genericService.GenericCRUD<DEPARTMENT>("GETBYID", dept);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", dept));
        }
    }
}
