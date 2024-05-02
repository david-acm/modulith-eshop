namespace eShop.Billing.Infrastructure;

public class FakeTemperatureService : ITemperatureService
{
  public int GetTemperature()
    => Random.Shared.Next(-20, 55);
}
