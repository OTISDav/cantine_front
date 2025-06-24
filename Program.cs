using FrontendApp;
using FrontendApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Utiliser l'URL de ton backend ici
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7001") });
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://276a-2c0f-f0f8-871-f100-efc1-9c91-83f9-a439.ngrok-free.app") });

builder.Services.AddScoped<StorageService>();
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddScoped<ApiService>();

await builder.Build().RunAsync();
