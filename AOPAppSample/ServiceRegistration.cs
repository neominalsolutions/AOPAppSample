using AOPAppSample.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace AOPAppSample
{
  // ServiceRegistration Lib. 
  public static class ServiceRegistration
  {
    public static IServiceCollection RegisterAllModule(this IServiceCollection services,
     WebApplicationBuilder webApplicationBuilder)
    {
      webApplicationBuilder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
      {
        // Autofac container builder ContainerBuilder  
        // builder.RegisterType<TestService>().As<ITestService>().SingleInstance();
        builder.RegisterModule(new AopModule());
      });

      services.AddScoped<ITestService, TestService>();

      return services;
    }
  }
}
