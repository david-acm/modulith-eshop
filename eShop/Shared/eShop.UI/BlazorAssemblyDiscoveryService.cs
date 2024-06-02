using System.Reflection;

namespace eShop.UI;

public class BlazorAssemblyDiscoveryService : IBlazorAssemblyDiscoveryService
{
  private static string SolutionName => "eShop";

  public IEnumerable<Assembly> GetAssemblies()
  {
    if (OperatingSystem.IsBrowser())
    {
      return GetClientSideAssemblies();
    }

    return GetServerSideAssemblies();
  }
        
  private static IEnumerable<Assembly> GetClientSideAssemblies() => AppDomain.CurrentDomain.GetAssemblies()
    .Where(c => c.GetName().Name?.Contains("UI") ?? false)
    .ToList();

  private static IEnumerable<Assembly> GetServerSideAssemblies()
  {
    var assemblyNames = GetServerSideAssemblyNames();
    var assemblies    = new List<Assembly>();

    assemblyNames.ForEach(f => assemblies.Add(Assembly.LoadFrom(f)));

    return assemblies;
  }
        

  private static List<string> GetServerSideAssemblyNames()
    => Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"{SolutionName}.*.UI.dll").ToList();
}

