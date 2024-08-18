using eShop.Shipments.HttpModels;
namespace eShop.Shipments;

internal interface IWeatherForecastService
{
  Task<IEnumerable<WeatherForecastResponse>> GetWeatherForecastAsync();
}
