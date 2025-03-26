using IncomeGoalTracker.Core.Interfaces;
using IncomeGoalTracker.Core.Services.Implementations;
using IncomeGoalTracker.Core.Services.Interfaces;
using IncomeGoalTracker.Data.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddLogging(logging =>
    {
    builder.Logging.SetMinimumLevel(LogLevel.Information);
});

builder.Services.AddScoped<ICertificateService, CertificateService>();
builder.Services.AddScoped<ICertificateRepo, CertificateRepo>();
await builder.Build().RunAsync();
