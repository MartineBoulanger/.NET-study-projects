using ATP.Blazor.Client.Services;
using ATP.Blazor.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<PlayersService>();
builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri("https://localhost:7000/") });

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();

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
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ATP.Blazor.Client._Imports).Assembly);

app.Run();
