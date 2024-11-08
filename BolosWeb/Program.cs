using BolosWeb;
using BolosWeb.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddScoped<RequisicaoBolo>(); // Registra o serviço RequisicaoBolo
builder.Services.AddHttpClient("BolosAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7252/"); // Use a URL da sua API
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
