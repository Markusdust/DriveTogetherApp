global using DriveTogetherApp.Shared;
global using DriveTogetherApp.Client.Services.AuthService;
global using DriveTogetherApp.Client.Services.AutoService;
global using DriveTogetherApp.Client.Services.FahrtService;
global using Microsoft.AspNetCore.Components.Authorization;
global using DriveTogetherApp.Client.Services.BuchungService;
using DriveTogetherApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using DriveTogetherApp.Client.Services.BuchungService;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAutoService, AutoService>();
builder.Services.AddScoped<IFahrtService, FahrtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBuchungService, BuchungService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
