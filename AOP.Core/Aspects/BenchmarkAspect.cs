using Castle.DynamicProxy;

namespace AOPAppSample.Aspects
{
  [AttributeUsage(AttributeTargets.Method)]
  public class LogAttribute: Attribute
  {

  }


  public class BenchMarkAspect : IInterceptor
  {
    public void Intercept(IInvocation invocation)
    {

      var method = invocation.MethodInvocationTarget ?? invocation.Method;

      if (method.GetCustomAttributes(typeof(LogAttribute), true).Any())
      {
        Console.WriteLine($"Method {method.Name} is called");
        invocation.Proceed();
      }
      else
      {
        Console.WriteLine("Method Not Implemented");
      }
   
    }
  }
}
