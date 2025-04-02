using ProDevTracker.Client.Pages;
using ProDevTracker.Components;
using Microsoft.Data.SqlClient;
using Radzen;
using Radzen.Blazor;
using IncomeGoalTracker.Data;
using IncomeGoalTracker.Data.Repositories;
using IncomeGoalTracker.Core.Interfaces;
using IncomeGoalTracker.Core.Services.Implementations;
using IncomeGoalTracker.Core.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add 3rd party UI services
builder.Services.AddRadzenComponents();

// Budiness and database logic services
builder.Services.AddSingleton<IDbConnectionFactory>(c => new SqlConnectionFactory(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICertificateRepo, CertificateRepo>();


builder.Services.AddScoped<ICertificateService, CertificateService>();

// Add Logging services
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddLogging(logging =>
    {
        logging.AddConsole();
        logging.AddDebug();
    });
}
else
{
    builder.Services.AddApplicationInsightsTelemetry();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ProDevTracker.Client._Imports).Assembly);

app.Run();
