using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System.Diagnostics;

namespace AOPAppSample.Aspects
{
  public class ErrorHandlingAspect : Attribute, IInterceptor
  {
    

    public void Intercept(IInvocation invocation)
    {

      Stopwatch sw = new Stopwatch();
      sw.Start();

      try
      {
        // Before
        Console.WriteLine($"İşlem başarılı Start: {sw.ElapsedMilliseconds}");
        invocation.Proceed();
        // sonraki adıma geç demek after olur
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
      finally {
        Console.WriteLine($"İşlem bitti Stop: {sw.ElapsedMilliseconds}");
        sw.Stop();
      }
      
    }
  }
}
