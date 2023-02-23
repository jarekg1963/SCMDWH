using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SCMDWH.Client;
using SCMDWH.Client.AuthProviders;
using SCMDWH.Client.Brokers.Api;
using SCMDWH.Client.Logging;
using SCMDWH.Client.Services;
using SCMDWH.Client.Services.GlobalUsers;
using System.Globalization;
using Microsoft.JSInterop;

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
//builder.Services.AddScoped<AuthenticationStateProvider, TestAuthStateProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();


builder.Services.AddScoped<IApiBroker, ApiBroker>();

builder.Services.AddScoped<IGlobalUsersService, GlobalUsersService>();

// serwis do idCA uzytkownik i rola 
//builder.Services.AddSingleton<StateContainer>();


CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pl-PL");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pl-PL");

// await builder.Build().RunAsync();

// added localization 

builder.Services.AddLocalization();

var host = builder.Build();

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