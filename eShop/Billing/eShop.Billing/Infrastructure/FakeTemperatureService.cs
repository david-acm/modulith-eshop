namespace eShop.Billing.Infrastructure;

internal class FakeTemperatureService : ITemperatureService
{
  public int GetTemperature()
    => Random.Shared.Next(-20, 55);
}
