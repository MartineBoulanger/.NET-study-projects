using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Tuincentrum;
using Tuincentrum.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo> {
        new CultureInfo("nl-BE"),
        new CultureInfo("nl"),
        new CultureInfo("fr-BE"),
        new CultureInfo("fr"),
        new CultureInfo("en-GB"),
        new CultureInfo("en")
    };
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.DefaultRequestCulture = new RequestCulture("nl-BE");
});
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews((options) => { 
    options.ModelBinderProviders.Insert(0, new CustomBinderProvider()); 
    //options.Filters.Add(new Tuincentrum.Filters.StatistiekActionFilter()); // om er een globale fiilter van te maken
}).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization(); // aangeven op welke manier de resource file moeten worden opgeslagen - suffix & SubFolder
builder.Services.AddDbContext<MvctuinCentrumContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TuincentrumConnection"))); // connetion to db
builder.Services.AddTransient<ILeveranciersRepository, SQLLeveranciersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseRequestLocalization();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
