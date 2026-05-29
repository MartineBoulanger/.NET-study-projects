using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using Tuincentrum.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RequestLocalizationOptions>(options => {
    var supportedCultures = new List<CultureInfo> { 
        new CultureInfo ( "nl - BE" ),
        new CultureInfo ( "nl" ),
        new CultureInfo ( "fr - BE" ),
        new CultureInfo ( "fr" )
    };
    options.SupportedCultures = supportedCultures; options.SupportedUICultures = supportedCultures;
    options.DefaultRequestCulture = new RequestCulture("nl - BE"); 
});
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources" );
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization(); // aangeven op welke manier de resource file moeten worden opgeslagen - suffix & SubFolder
builder.Services.AddDbContext<MvctuinCentrumContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TuincentrumConnection"))); // connetion to db
builder.Services.AddTransient<ILeveranciersRepository, SQLLeveranciersRepository>();

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
app.UseRequestLocalization();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
