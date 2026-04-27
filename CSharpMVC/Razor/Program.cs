using Razor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews(); // dit is de standaard
builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider(); // om temdata te gebruiken via sessions
// zorgen dan session variabele kunnen worden gebruikt
builder.Services.AddSession();
// services toevoegen voor DI
builder.Services.AddSingleton<FiliaalService>();
builder.Services.AddSingleton<PersoonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession(); // zodat sessions gebruikt kunnen worden
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
