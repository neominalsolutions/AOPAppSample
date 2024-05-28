using AOPAppSample.Aspects;
using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace AOPAppSample.Services
{
  public class TestService : ITestService
  {

    [LogAspect]
    public void Do(int quantity)
    {
      // throw new Exception("Hata");
    }
  }
}
