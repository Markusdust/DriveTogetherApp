global using DriveTogetherApp.Shared;
global using Microsoft.EntityFrameworkCore;
global using DriveTogetherApp.Server.Data;
global using DriveTogetherApp.Server.Services.AutoService;
global using DriveTogetherApp.Server.Services.FahrtService;
global using DriveTogetherApp.Server.Services.AuthService;
global using DriveTogetherApp.Server.Services.BuchungService;
global using DriveTogetherApp.Server.Services.EmailService;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Blazored.LocalStorage;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IAutoService, AutoService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFahrtService, FahrtService>();
builder.Services.AddScoped<IBuchungService, BuchungService>();
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer =false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
