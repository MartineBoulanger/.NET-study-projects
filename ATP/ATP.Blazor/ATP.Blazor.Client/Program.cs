using ATP.Blazor.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<PlayersService>();
builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri("https://localhost:7000/") });

await builder.Build().RunAsync();
