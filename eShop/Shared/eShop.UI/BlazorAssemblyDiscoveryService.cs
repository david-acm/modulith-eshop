using System.Reflection;
using eShop.Payments.UI;
using eShop.Shipments.UI;

namespace eShop.UI;

public class BlazorAssemblyDiscoveryService : IBlazorAssemblyDiscoveryService
{
  public IEnumerable<Assembly> GetAssemblies()
  {
      return [typeof(PaymentsComponent).Assembly, typeof(ShipmentsComponent).Assembly];
  }
}

