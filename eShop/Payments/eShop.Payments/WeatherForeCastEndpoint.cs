using eShop.Payments.HttpModels;
using FastEndpoints;

namespace eShop.Payments;

internal class WeatherForeCastEndpoint(IWeatherForecastService weatherForecastService) : EndpointWithoutRequest<IEnumerable<WeatherForecastResponse>>
{
  public override void Configure()
  {
    AllowAnonymous();
    Get("/Payments/weatherforecast");
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    await SendOkAsync(await weatherForecastService.GetWeatherForecastAsync(), ct);
  }
}
