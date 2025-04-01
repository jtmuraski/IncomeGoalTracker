using IncomeGoalTracker.Client.Pages;
using IncomeGoalTracker.Components;
using IncomeGoalTracker.Core.Interfaces;
using Microsoft.Data.SqlClient;
using MudBlazor.Services;
using IncomeGoalTracker.Data;
using IncomeGoalTracker.Data.Repositories;
using IncomeGoalTracker.Core.Services.Implementations;
using IncomeGoalTracker.Core.Services.Interfaces;
using Microsoft.AspNetCore.Components.Server;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<IDbConnectionFactory>(c => new SqlConnectionFactory(builder.Configuration.GetConnectionString("DefaultConnection")));

// Database Repo instances
builder.Services.AddScoped<ICertificateRepo, CertificateRepo>();
builder.Services.AddScoped<ITrainingClassRepo, TrainingClassRepo>();
builder.Services.AddScoped<IClassCeuRepo, ClassCeuRepo>();
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
    .AddAdditionalAssemblies(typeof(IncomeGoalTracker.Client._Imports).Assembly);

app.Run();
