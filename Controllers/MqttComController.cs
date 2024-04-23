using Microsoft.AspNetCore.Mvc;

namespace TISM_Api.Controllers
{
    [ApiController]
    [Route("mqtt/com")]
    public class MqttComController : ControllerBase
    {
        private readonly ILogger<MqttComController> _logger;

        public MqttComController(ILogger<MqttComController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Sensors Get()
        {
            return MqttClient_TISM.Sensors;
        }
    }
}
