using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using DP_SUM0023.Authentication;
using DP_SUM0023.Data;
using DP_SUM0023.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// setup blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// setup authentication
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// setup database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
    throw new Exception("No connection string found in application settings, aborting application startup!");

// entity framework connection
builder.Services.AddDbContext<CustomDbContext>((DbContextOptionsBuilder options) =>
    options.UseMySQL(connectionString));

// backup direct MySql connection - use this as a fallback option
//builder.Services.AddScoped(_ => new MySqlConnector.MySqlConnection(connectionString));

// setup custom services
builder.Services.AddSingleton<WeatherForecastService>(); //TODO: Get rid of this and the related classes
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
