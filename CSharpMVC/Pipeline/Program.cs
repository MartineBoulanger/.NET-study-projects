var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/Error");
    app.UseHsts();
}

app.UseStaticFiles(); // nog altijd nodig hier om static HTML pageina's te kunnen tonen
app.MapStaticAssets();
//app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();

app.Run();
