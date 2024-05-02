using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using eShop.Billing.Api;

namespace eShop.Billing.Tests;

public class WeatherForecastEndpointShould(BillingFixture fixture) : TestBase<BillingFixture>
{
  [Fact]
  public async Task ReturnWeatherForecastDataAsync()
  {
    var call = await fixture.Client.GETAsync<WeatherForecastEndpoint, WeatherForecastResponse[]>();

    call.Response.EnsureSuccessStatusCode();
    call.Result.Should().HaveCount(5);
  }
}