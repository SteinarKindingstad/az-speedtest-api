using Microsoft.AspNetCore.Mvc;
using SpeedTestApi.Models;
using SpeedTestApi.Services;
using System.Threading.Tasks;

namespace SpeedTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpeedTestController : ControllerBase
    {
        private readonly ISpeedTestEvents _eventHub;

        public SpeedTestController(ISpeedTestEvents eventHub)
        {
            _eventHub = eventHub;
        }

        public async Task<ActionResult<string>> UploadSpeedTest([FromBody] TestResult speedTest)
        {
            await _eventHub.PublishSpeedTest(speedTest);

            var speedTestData = $"Got a TestResult from { speedTest.User } with download { speedTest.Data.Speeds.Download } Mbps.";

            return Ok(speedTestData);
        }

        // GET speedtest/ping
        [Route("ping")]
        [HttpGet]
        public ActionResult<string> Ping()
        {
            return Ok("PONG");
        }

        // // POST speedtest/
        // [HttpPost]
        // public ActionResult<string> UploadSpeedTest([FromBody] TestResult speedTest)
        // {
        //     var speedTestData = $"Got a TestResult from { speedTest.User } with download { speedTest.Data.Speeds.Download } Mbps.";

        //     return Ok(speedTestData);
        // }
    }
}