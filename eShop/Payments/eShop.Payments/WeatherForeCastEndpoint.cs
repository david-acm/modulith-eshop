using eShop.Payments.HttpModels;
using FastEndpoints;
using static System.DateOnly;
using static System.Random;

namespace eShop.Payments;

internal class WeatherForeCastEndpoint : EndpointWithoutRequest<WeatherForecastResponse[]>
{
  public override void Configure()
  {
    AllowAnonymous();
    Get("/Payments/weatherforecast");
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    string[] summaries =
      ["Freezing", "Bracing", "Chilly", "Cool", "Mild", 
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    await SendOkAsync(Enumerable.Range(1, 5)
      .Select(random =>
        new WeatherForecastResponse
        (
          FromDateTime(DateTime.Now.AddDays(random)),
          Shared.Next(-20, 55),
          summaries[Shared.Next(summaries.Length)]
        ))
      .ToArray(), ct);
  }
}
