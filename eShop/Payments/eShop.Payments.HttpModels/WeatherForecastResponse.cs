namespace eShop.Payments.HttpModels;

public class WeatherForecastResponse(
  DateOnly Date,
  int      TemperatureC,
  string   Summary)
{
  public DateOnly Date { get; } = Date;

  public int TemperatureC { get; } = TemperatureC;

  public string Summary { get; } = Summary;
  // public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
