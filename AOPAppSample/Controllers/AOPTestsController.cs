using AOPAppSample.Aspects;
using AOPAppSample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AOPAppSample.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AOPTestsController : ControllerBase
  {
   
 
    private readonly ITestService _testService;

    public AOPTestsController(ITestService testService)
    {
      _testService = testService;
    }

    [HttpGet]
    public IActionResult Get()
    {
      _testService.Execute();

      return Ok();
    }
  }
}