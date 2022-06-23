using Flurl.Http;
using HikRCS.Client.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HikRCSIntegration.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHikRobotService _robotService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHikRobotService robotService)
        {
            _logger = logger;
            _robotService = robotService;
            var tv = (success: false, message: "error");
            var str = JsonSerializer.Serialize(tv);
            logger.LogInformation(str);
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _robotService.FreeRobot(new HikRCS.Client.Models.HikFreeRobotModel
            {
                reqCode = "0",
                robotCode = "00"
            });
            var response = "http://www.baidu.com".GetStringAsync().Result;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}