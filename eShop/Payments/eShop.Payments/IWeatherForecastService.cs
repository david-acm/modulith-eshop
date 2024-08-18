using eShop.Payments.HttpModels;
namespace eShop.Payments;

internal interface IWeatherForecastService
{
  Task<IEnumerable<WeatherForecastResponse>> GetWeatherForecastAsync();
}
