using System.Reflection;
using eShop.Payments.UI;
using eShop.UI;

namespace eShop.UI;

public class BlazorAssemblyDiscoveryService : IBlazorAssemblyDiscoveryService
{
  public IEnumerable<Assembly> GetAssemblies()
  {
      return [typeof(PaymentsComponent).Assembly];
  }
}

