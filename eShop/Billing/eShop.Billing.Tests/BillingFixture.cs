using FastEndpoints.Testing;
using eShop.Web;

namespace eShop.Billing.Tests;

public class BillingFixture : AppFixture<Program>
{
  protected override async Task SetupAsync()
  {
    Client = CreateClient();

    await base.SetupAsync();
  }

  protected override async Task TearDownAsync()
  {
    Client.Dispose();
    await base.TearDownAsync();
  }
}
