using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using eShop.Payments;
using eShop.Payments.UI;
using eShop.UI.Pages;
using eShop.UI;
using eShop.Web.Components;
using MudBlazor.Services;
using MudBlazor.Extensions;
using eShop.Web;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Call the method where you are registering services for each module:
// PaymentsModuleServiceRegistrar.ConfigureServices(builder);

// Or use the discover method below to try and find the services for your modules
builder.DiscoverAndRegisterModules();

builder.Services
  .AddAuthenticationJwtBearer(s =>
  {
    // TODO: Add dotnet secrets
    s.SigningKey = builder.Configuration["Auth:JwtSecret"];
  })
  .AddAuthorization()
  .SwaggerDocument()
  .AddFastEndpoints();

// Add services to the container.
builder.Services.AddRazorComponents()
  .AddInteractiveServerComponents()
  .AddInteractiveWebAssemblyComponents();

builder.Services.AddMudServices();
builder.Services.RegisterPaymentsSpaServices();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles()
  .UseWebAssemblyDebugging();

// Use FastEndpoints
app.UseAuthentication()
  .UseAuthorization()
  .UseRouting()
  .UseAntiforgery()
  .UseFastEndpoints()
  .UseSwaggerGen();
var componentBuilder = app.MapRazorComponents<App>()
  .AddInteractiveServerRenderMode()
  .AddInteractiveWebAssemblyRenderMode()
  .AddAdditionalAssemblies(typeof(Counter).Assembly);
  
componentBuilder.AddAdditionalAssemblies(
  typeof(ModularComponent).Assembly,
  typeof(eShop.Shipments.UI.ShipmentsComponent).Assembly);

app.Run();

namespace eShop.Web
{
  public partial class Program
  {
    
  }
}