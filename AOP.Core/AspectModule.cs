
using AOPAppSample.Aspects;
using Autofac;
using Autofac.Extras.DynamicProxy;
using System.Reflection;

namespace AOPAppSample
{
  public class AspectModule: Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<BenchMarkAspect>();
    }
  }
}
