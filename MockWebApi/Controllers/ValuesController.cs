using Microsoft.AspNetCore.Mvc;
using Logger;
using ILogger = Logger.ILogger;

namespace MockWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;

        public ValuesController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("sum/{x}/{y}")]
        public int Sum(int x, int y)
        {
            _logger.Log($"Sum endpoint called with x={x} and y={y}");
            return x + y;
        }

        [HttpGet]
        [Route("ping")]
        public string Ping()
        {
            _logger.Log("Ping endpoint called");
            return "Ping successful!";
        }
    }
}
