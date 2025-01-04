using BlazorUnicode.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<BlazorUnicode.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(_ => httpClient);

var unicodeCharacterDatabase = new UnicodeCharacterDatabase(httpClient);
await unicodeCharacterDatabase.LoadDataAsync();
builder.Services.AddScoped(_ => unicodeCharacterDatabase);

await builder.Build().RunAsync();
