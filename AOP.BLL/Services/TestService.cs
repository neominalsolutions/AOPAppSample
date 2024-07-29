
using AOPAppSample.Aspects;

namespace AOPAppSample.Services
{
  public class TestService : ITestService
  {

    [Log]
    public void Execute(params string[] @params)
    {
      // throw new Exception("Hata");
    }
  }
}
