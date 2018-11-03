using Microsoft.AspNetCore.Mvc;
using SpeedTestApi.Models;

namespace SpeedTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpeedTestController : ControllerBase
    {
        // GET speedtest/ping
        [Route("ping")]
        [HttpGet]
        public ActionResult<string> Ping()
        {
            return Ok("PONG");
        }

        // POST speedtest/
        [HttpPost]
        public ActionResult<string> UploadSpeedTest([FromBody] TestResult speedTest)
        {
            var speedTestData = $"Got a TestResult from { speedTest.User } with download { speedTest.Data.Speeds.Download } Mbps.";

            return Ok(speedTestData);
        }
    }
}