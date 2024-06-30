using eShop.Payments.HttpModels;

namespace eShop.Payments.HttpModels;

public interface IWeatherForecastService
{
  Task<IEnumerable<WeatherForecastResponse>> GetWeatherForecastAsync();
}
