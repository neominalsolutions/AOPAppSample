using Castle.DynamicProxy;

namespace AOPAppSample.Aspects
{
  public class LogAspect : Attribute, IInterceptor
  {
    public void Intercept(IInvocation invocation)
    {
      throw new NotImplementedException();
    }
  }
}
