using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SCMDWH.Client;
using SCMDWH.Client.AuthProviders;

using SCMDWH.Client.Logging;
using SCMDWH.Client.Services;

using System.Globalization;
using Microsoft.JSInterop;
using SCMDWH.Client.JGHttpClient;
using SCMDWH.Client.Tools;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

builder.Services.AddLogging(logging => {
    var httpClient = builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>();
    logging.SetMinimumLevel(LogLevel.Error);
    logging.ClearProviders();
    logging.AddProvider(new ApplicationLoggerProvider(httpClient));
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();


builder.Services.AddLocalization();

builder.Services.AddScoped<JGHttpClient>();
builder.Services.AddScoped<RecordLog>();



var host = builder.Build();
// start localozation 

CultureInfo culture;
var js = host.Services.GetRequiredService<IJSRuntime>();
var result = await js.InvokeAsync<string>("blazorCulture.get");

if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("pl-PL");
    await js.InvokeVoidAsync("blazorCulture.set", "pl-PL");
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();

// end localozation 