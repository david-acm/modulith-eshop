using eShop.UI;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.RegisterPaymentsSpaServices();
builder.Services.AddScoped(sp =>
  new HttpClient
  {
    BaseAddress = new Uri("http://localhost:5183")
  });

await builder.Build().RunAsync();
