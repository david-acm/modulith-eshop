using eShop.Payments.HttpModels;
using eShop.SharedKernel;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Payments.UI;

public class ShipmentsUiModuleServiceRegistrar : IRegisterModuleServices
{
  public static IServiceCollection ConfigureServices(IServiceCollection services)
  {
    services.AddScoped<IWeatherForecastService, ClientWeatherForecastService>();

    return services;
  }
}
