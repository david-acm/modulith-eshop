namespace eShop.Billing.Api;

internal interface IWeatherForecastService
{
  WeatherForecastResponse[] GetWeatherForecast(string[] summaries);
}
