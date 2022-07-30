using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MessangerAndWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OthersController : ControllerBase
    {
        private readonly IOthersService _servicesOthers;
        private readonly IEmailService _emailService;
        public OthersController(IOthersService servicesOthers, IEmailService emailService)
        {
            _servicesOthers = servicesOthers;
            _emailService = emailService;
        }


        // https://localhost:44372/api/Others/SEALESYEAR [Get] 
        // No Data Pass

        [HttpGet("SEALESYEAR")]
        public async Task<IActionResult> SealesYear()
        {
            return Ok(await _servicesOthers.GetSealesYear());
        }

        // This Method To Return NUMBER OF LIKE IN EACH POST
        // https://localhost:44372/api/Others/GETLIKEALL [Get] 
        // No Data Pass
        [HttpGet("GETLIKEALL")]
        public async Task<IActionResult> GETLIKEALL()
        {
            return Ok(await _servicesOthers.GETLIKEALL());
        }

        // This Method To Return NUMBER OF POST IN EACH USER
        // https://localhost:44372/api/Others/GETUSERPOSTS [Get] 
        // No Data Pass
        [HttpGet("GETUSERPOSTS")]
        public async Task<IActionResult> GETUSERPOSTS()
        {
            return Ok(await _servicesOthers.GETUSERPOSTS());
        }

        // https://localhost:44372/api/USER1/GetCityNumberOfUser1 [Get] 
        // No Data Pass

        [HttpGet("GetCityNumberOfUser1")]
        public async Task<IActionResult> GetCityNumberOfUser1()
        {
            return Ok(await _servicesOthers.GetCityNumberOfUser1());
        }

        // https://localhost:44372/api/USER1/TotalVisaUser1 [Get] 
        // No Data Pass

        [HttpGet("TotalVisaUser1")]
        public async Task<IActionResult> TotalVisaUser1()
        {
            return Ok(await _servicesOthers.TotalVisaUser1());
        }

        // https://localhost:44372/api/FRIEND/GetAllRequesFrindByUser [Get] 
        // Data {"TOUSER": 29}

        [HttpGet("GetAllRequesFrindByUser")]
        public async Task<IActionResult> GetAllRequesFrindByUser([FromBody] FRIEND friend)
        {
            return Ok(await _servicesOthers.GetAllRequesFrindByUser(friend.TOUSER));
        }

        // https://localhost:44372/api/FRIEND/GetAllFrindByUser [Get] 
        // Data {"TOUSER": 29}

        [HttpGet("GetAllFrindByUser")]
        public async Task<IActionResult> GetAllFrindByUser([FromBody] FRIEND friend)
        {
            return Ok(await _servicesOthers.GetAllFrindByUser(friend.TOUSER));
        }

        // https://localhost:44372/api/FRIEND/ApprovedFrindReguest [Get] 
        // Data {"id": 4}
        [HttpPost("ApprovedFrindReguest")]
        public async Task<IActionResult> ApprovedFrindReguest([FromBody] FRIEND friend)
        {
            return Ok(await _servicesOthers.ApprovedFrindReguest(friend.ID));
        }

        // https://localhost:44372/api/FRIEND/BlockFrind [Get] 
        // Data {"id": 4}
        [HttpPost("BlockFrind")]
        public async Task<IActionResult> BlockFrind([FromBody] FRIEND friend)
        {
            var res = await _servicesOthers.GetEmailBlockFrind(friend.ID);
            if (res == null)
                return BadRequest();
            _emailService.SendBlockEmail(res);
            return Ok(await _servicesOthers.BlockFrind(friend.ID));
        }

        [HttpGet("GetAllMessageByGroubUser1")]
        public async Task<IActionResult> GetAllMessageByGroubUser1()
        {
            return Ok(await _servicesOthers.GetAllMessageByGroubUser1());
        }

        [HttpGet("GetAllMessageCountbyAllUser")]
        public async Task<IActionResult> GetAllMessageCountbyAllUser()
        {
            return Ok(await _servicesOthers.GetAllMessageCountbyAllUser());
        }

        [HttpGet("GetAllMessageCountbyAllGroup")]
        public async Task<IActionResult> GetAllMessageCountbyAllGroup()
        {
            return Ok(await _servicesOthers.GetAllMessageCountbyAllGroup());
        }

        [HttpGet("backup/{userName}")]
        public async Task<IActionResult> getAllMessagebyUsers(string userName)
        {
            var res = await _servicesOthers.getAllMessagebyUsers(userName);
            string path = @"path here";

            FileInfo fileInfo = new FileInfo(path);
            try
            {
                // Create the file, or overwrite if the file exists.
                using (StreamWriter fs = fileInfo.CreateText())
                {
                    foreach (var item in res)
                    {
                        fs.WriteLine("CreateAt : {0}   ,  Message is : {1}   ,   Group Name : {2}", item.CREATEAT, item.CONTENT1, item.NAME);
                    }
                    fs.Close();
                }
                return Ok($"Create File BackUp {userName} Get ALL Message");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


    }
}
