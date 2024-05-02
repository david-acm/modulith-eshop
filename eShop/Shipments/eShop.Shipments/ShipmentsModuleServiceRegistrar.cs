using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using eShop.SharedKernel;

namespace eShop.Shipments;

public class ShipmentsModuleServiceRegistrar : IRegisterModuleServices
{
  public static IHostApplicationBuilder ConfigureServices(IHostApplicationBuilder builder)
  {
    builder.Services.AddMediatR(
      c => c.RegisterServicesFromAssemblies(typeof(AssemblyInfo).Assembly));

    return builder;
  }
}