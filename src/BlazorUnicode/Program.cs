using BlazorUnicode.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<BlazorUnicode.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorUnicode", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorUnicode.ServerAPI"));

//builder.Services.AddScoped<UnicodeCharacterDatabase>(service =>
//    new UnicodeCharacterDatabase(
//        service.GetRequiredService<HttpClient>()
//    )
//);
builder.Services.AddScoped<UnicodeCharacterDatabase>();

await builder.Build().RunAsync();
