using AOPAppSample;
using AOPAppSample.Aspects;
using AOPAppSample.ServiceInstances;
using AOPAppSample.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ScopeServiceInstance>();
builder.Services.AddTransient<TransientServiceInstance>();
builder.Services.AddSingleton<SingletonServiceInstance>();


// Scoped => Web Request i�in �zel olarak geli�tirildi. Web Request bazl� Instance al�r  => InstancePerLifetimeScope


// Autofac ile t�m Aspectleri register edelim. Reflection scanning �zelli�i ile yapal�m


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
  // Autofac container builder ContainerBuilder  
  builder.RegisterType<TestService>().As<ITestService>().InstancePerRequest(); // web request
  builder.RegisterType<TestService>().As<ITestService>().SingleInstance();
  builder.RegisterType<TestService>().As<ITestService>().InstancePerLifetimeScope(); // Transient
  builder.RegisterModule(new AopModule());
});


builder.Services.RegisterAllModule(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
