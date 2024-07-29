using AOPAppSample;
using AOPAppSample.Aspects;
using AOPAppSample.Services;
using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.BLL
{
  public class BussinessModule:Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterModule(new AspectModule());

      builder.RegisterType<TestService>().As<ITestService>()
        .EnableInterfaceInterceptors()
        .InterceptedBy(typeof(BenchMarkAspect));

      base.Load(builder);
    }
  }
}
