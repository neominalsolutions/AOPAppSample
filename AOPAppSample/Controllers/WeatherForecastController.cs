using AOPAppSample.Aspects;
using AOPAppSample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AOPAppSample.Controllers
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
    private readonly ITestService _testService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ITestService testService)
    {
      _logger = logger;
      _testService = testService;

    }

    [HttpGet(Name = "GetWeatherForecast")]
    [ErrorHandlingAspect]
    public IActionResult Get()
    {
      // controllerlarýn içerisinde herhangi bir try catch yazmadan yukarýdaki [ErrorHandlingAspect] attribute düþtük.

      // clean code deðil
      //try
      //{
      //  _testService.Do(15);
      //  _logger.LogInformation("sdsadsad");
      //}
      //catch (Exception)
      //{
      //  _logger.LogInformation("sdsadsad");
      //  throw;
      //}

      _testService.Do(15);


      return Ok("Test");
     
    }
  }
}