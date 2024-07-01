using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using eShop.Billing.Api;
using eShop.Billing.Infrastructure;
using eShop.SharedKernel;

namespace eShop.Billing;

public class BillingServiceRegistrar : IRegisterModuleServices
{
  public static IServiceCollection ConfigureServices(IServiceCollection services)
  {
    var logger = GetLogger(services);
    services.AddMediatR(
      c => c.RegisterServicesFromAssemblies(typeof(AssemblyInfo).Assembly));

    services.AddScoped<IWeatherForecastService, WeatherForecastService>();
    services.AddScoped<ITemperatureService, FakeTemperatureService>();
    
    logger.LogInformation("⚙️ Billing module services registered");

    return services;
  }
  
  private static ILogger<IServiceCollection> GetLogger(IServiceCollection services)
    => services
      .BuildServiceProvider()
      .GetRequiredService<ILogger<IServiceCollection>>();
}
