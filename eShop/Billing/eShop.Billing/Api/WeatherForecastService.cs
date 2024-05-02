using eShop.Billing.Infrastructure;

namespace eShop.Billing.Api;

internal class WeatherForecastService(ITemperatureService
    temperatureService) : IWeatherForecastService
{
  public WeatherForecastResponse[] GetWeatherForecast(string[] summaries)
  {

    return Enumerable.Range(1, 5)
      .Select(random =>
        new WeatherForecastResponse
        (
          DateOnly.FromDateTime(DateTime.Now.AddDays(random)),
          temperatureService.GetTemperature(),
          summaries[Random.Shared.Next(summaries.Length)]
        ))
      .ToArray();
  }
}
