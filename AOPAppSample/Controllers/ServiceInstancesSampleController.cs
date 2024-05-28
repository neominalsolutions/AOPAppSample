using AOPAppSample.ServiceInstances;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AOPAppSample.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ServiceInstancesSampleController : ControllerBase
  {
    // dependent bir kullanım örneği 

    // private readonly ScopeServiceInstance scope1 = new ScopeServiceInstance();
    private readonly ScopeServiceInstance scope1;
    private readonly ScopeServiceInstance scope2;

    private readonly TransientServiceInstance transient1;
    private readonly TransientServiceInstance transient2;

    private readonly SingletonServiceInstance singleton1;
    private readonly SingletonServiceInstance singleton2;

    public ServiceInstancesSampleController(ScopeServiceInstance scope1, ScopeServiceInstance scope2, TransientServiceInstance transient1, TransientServiceInstance transient2, SingletonServiceInstance singleton1, SingletonServiceInstance singleton2)
    {
      this.scope1 = scope1;
      this.scope2 = scope2;
      this.transient1 = transient1;
      this.transient2 = transient2;
      this.singleton1 = singleton1;
      this.singleton2 = singleton2;
    }

    [HttpGet]
    public IActionResult Test()
    {
      var response = Tuple.Create(this.scope1, this.scope2, this.transient1, this.transient2, this.singleton1, this.singleton2);

      return Ok(response);
    }
  }
}
