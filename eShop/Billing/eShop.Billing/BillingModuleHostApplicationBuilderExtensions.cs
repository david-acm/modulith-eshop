using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using eShop.Billing.Api;
using eShop.Billing.Infrastructure;
using eShop.SharedKernel;

namespace eShop.Billing;

public class BillingServiceRegistrar : IRegisterModuleServices
{
  public static IHostApplicationBuilder ConfigureServices(IHostApplicationBuilder builder)
  {
    var logger = GetLogger(builder);
    builder.Services.AddMediatR(
      c => c.RegisterServicesFromAssemblies(typeof(AssemblyInfo).Assembly));

    builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
    builder.Services.AddScoped<ITemperatureService, FakeTemperatureService>();
    
    logger.LogInformation("⚙️ Billing module services registered");

    return builder;
  }
  
  private static ILogger<WebApplicationBuilder> GetLogger(IHostApplicationBuilder builder) 
    => builder.Services
      .BuildServiceProvider()
      .GetRequiredService<ILogger<WebApplicationBuilder>>();
}
