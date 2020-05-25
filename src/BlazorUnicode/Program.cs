using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorUnicode.Models;
using System.IO;
using System.Net.Http.Json;
using System.Threading;

namespace BlazorUnicode {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Cannot await. Single-thread
            //builder.Services.AddSingleton<UnicodeCharacterDatabase>((serviceProvider) => {
            //    var client = serviceProvider.GetService<HttpClient>();
            //    var db = new UnicodeCharacterDatabase(client);
            //    db.LoadDataAsync();
            //    return db;
            //});

            // Load the data here 
            var serviceProvider = builder.Services.BuildServiceProvider();
            var client = serviceProvider.GetService<HttpClient>();
            var db = new UnicodeCharacterDatabase(client);
            await db.LoadDataAsync(); // CAN await here
            builder.Services.AddSingleton<UnicodeCharacterDatabase>(_ => db);

            await builder.Build().RunAsync();
        }
                
    }
}
