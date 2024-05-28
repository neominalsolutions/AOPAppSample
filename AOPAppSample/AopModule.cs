
using AOPAppSample.Aspects;
using AOPAppSample.Services;
using Autofac;
using Autofac.Extras.DynamicProxy;
using System.Reflection;

namespace AOPAppSample
{
  public class AopModule: Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {

      builder.RegisterType<ErrorHandlingAspect>();
      builder.RegisterType<LogAspect>();

      // servis bazlı interception işlemi bu işlemde attribute olarak çağırmaya gerek yok
      // servis tanımlarken ara işlemleri yazabilmemiz gerekiyor.
      // Register our label maker service as a singleton
      // (so we only create a single instance)
      //builder.RegisterType<TestService>()
      //    .As<ITestService>()
      //    .SingleInstance()
      //    .EnableInterfaceInterceptors()
      //    .InterceptedBy(typeof(ErrorHandlingAspect));

      // tüm uyglama genelinde attribute bazlı bir interception işlemi yapılacak ise uygulanır. 
      var assembly = Assembly.GetExecutingAssembly();
      builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors().InterceptedBy(typeof(ErrorHandlingAspect),typeof(LogAspect)).SingleInstance();

    }
  }
}
