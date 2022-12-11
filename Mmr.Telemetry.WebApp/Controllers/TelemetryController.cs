using Microsoft.AspNetCore.Mvc;
using Mmr.Telemetry.WebApp;
using Mmr.Telemetry.WebApp.mqtt;
using Newtonsoft.Json;

namespace Mmr.Telemetry.WebApp.Controllers
{
    [Route("/telemetry")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ITelemetryManager telemetryManager;
        public TelemetryController(IConfiguration configuration, ITelemetryManager telemetryManager)
        {
            this.configuration = configuration;
            this.telemetryManager = telemetryManager;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(telemetryManager.Telemetries);
            return new JsonResult(jsonString);
        }
    }
}
