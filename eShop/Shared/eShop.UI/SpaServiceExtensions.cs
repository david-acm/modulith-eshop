using eShop.Payments.HttpModels;
using eShop.Payments.UI;
using MudBlazor.Services;

namespace eShop.UI;

public static class SpaServiceExtensions
{
  public static IServiceCollection RegisterPaymentsSpaServices(this IServiceCollection services)
  {
    services.AddMudServices();
    services.AddBlazorAssemblyDiscovery();

    services.AddScoped<IWeatherForecastService, ClientWeatherForecastService>();

    return services;
  }
}
