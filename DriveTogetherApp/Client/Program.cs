global using DriveTogetherApp.Shared;
global using DriveTogetherApp.Client.Services.AuthService;
global using DriveTogetherApp.Client.Services.AutoService;
using DriveTogetherApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAutoService, AutoService>();
builder.Services.AddScoped<IAuthService, AuthService>();

await builder.Build().RunAsync();
