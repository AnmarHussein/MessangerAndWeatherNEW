using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MessangerAndWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User1Controller : ControllerBase
    {
        private readonly IGenericService<USER1> _genericService;
        // To Get ID And Select Random DEPARTMENT AND ROLE
        private readonly IGenericService<DEPARTMENT> _department1Servers;
        private readonly IGenericService<ROLE> _roleService;
        public User1Controller(IGenericService<USER1> genericService, IGenericService<ROLE> roleService, IGenericService<DEPARTMENT> department1Servers)
        {
            _genericService = genericService;
            _roleService = roleService;
            _department1Servers = department1Servers;
        }

        // https://localhost:44372/api/User1/ReadDataUserInFile  [Post]
        // Form-data name = file  => Select The File Unites.txt
        [HttpPost("ReadDataUserInFile")]
        public async Task<bool> ReadDataUserInFile([FromForm] IFormFile file)
        {
            var deptID = _department1Servers.GenericCRUD<List<DEPARTMENT>>("GETALL",null).Result.Select(x=>x.ID).ToArray();
            var roleID = _roleService.GenericCRUD<List<ROLE>>("GETALL", null).Result.Select(x=>x.ID).ToArray();
            string[] emailDomain = { "@gmail.com", "@gmail.net", "@gmail.org" };

            // 6 City
            string[] city = { "AMMAN", "IRBID", "MAFRAQ", "AJLOUN", "AQABA" ,"JARASH"};

            using (var str = new StreamReader(file.OpenReadStream()))
            {
                Random rand = new Random();
                USER1 user1 = new USER1();
                string line = "";
                while ((line = str.ReadLine()) != null)
                {
                    user1.FullName = line;
                    user1.Password = rand.Next(1000000,10000000).ToString();
                    user1.EMAIL = String.Concat(user1.FullName.Where(c => !Char.IsWhiteSpace(c))) + emailDomain[rand.Next(emailDomain.Length)];
                    user1.UserName = String.Concat(user1.FullName.Where(c => !Char.IsWhiteSpace(c))) + rand.Next(100, 10000).ToString();  
                    user1.City = city[rand.Next(city.Length)];
                    user1.deptid = deptID[rand.Next(deptID.Length)];   
                    user1.roleid = roleID[rand.Next(roleID.Length)]; // Admin or User Random

                    await _genericService.GenericCRUD<USER1>("INSERT",user1);
                }
            }
            return true;
        }

        // https://localhost:44372/api/USER1 [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GenericCRUD<List<USER1>>("GETALL",null));
        }

        // https://localhost:44372/api/USER1/GetByID [Get] 
        // DATA FROM Body {"ID" : 2}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] USER1 user1)
        {
            return Ok(await _genericService.GenericCRUD<USER1>("GETBYID", user1));
        }

        //https://localhost:44372/api/USER1   [POST]
        /*Data From Body  {"FullName" : "Anmar Okour","Password" : "123123","Email" : "anmar.hussein.okour@gmail.com",
            "UserName" : "anmar99","City" : "Irbd","role_id" : 4,"dept_id" : 4}*/

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] USER1 user1)
        {
            var exi = await _genericService.GenericCRUD<USER1>("GETBYNAME", user1);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", user1));
        }

        //https://localhost:44372/api/USER1/InsertList   [POST]

        [HttpPost("InsertList")]
        public async Task<IActionResult> InsertList([FromBody] List<USER1> users1)
        {

            if (users1.Count < 1)
                return BadRequest("List is Empty !!");
            foreach(var user in users1)
            {
                if( await _genericService.GenericCRUD<USER1>("GETBYNAME", user) != null)
                    return BadRequest("Name IS Exiest !!");
                await _genericService.GenericCRUD<string>("INSERT",user);
            }

            return Ok("True");
        }

        //https://localhost:44372/api/USER1   [PUT]
        /*DATA FROM Body 
           { "ID" : 2 ,"FullName" : "Anmar Okour","Password" : "123123","Email" : "anmar.hussein.okour@gmail.com",
            "UserName" : "anmar99","City" : "Amman","role_id" : 4,"dept_id" : 4} */
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] USER1 user1)
        {
            var exi = await _genericService.GenericCRUD<USER1>("GETBYNAME", user1);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", user1));
        }

        //https://localhost:44372/api/User1   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] USER1 user1)
        {
            var exi = await _genericService.GenericCRUD<USER1>("GETBYID", user1);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", user1));
        }
    }
}
