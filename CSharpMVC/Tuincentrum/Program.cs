using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Tuincentrum;
using Tuincentrum.Constraints;
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
builder.Services.Configure<RouteOptions>(options => options.ConstraintMap.Add("values", typeof(ValuesConstraint)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //app.UseStatusCodePages();
    app.UseStatusCodePagesWithRedirects("/Home/StatusCodeErrorPage?statusCode={0}");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseRequestLocalization();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "FindPlantenByPrijsBetween",
    pattern: "planten",
    defaults: new { controller = "Plant", action = "FindPlantenBetweenPrijzen" },
    constraints: new { query = new QueryStringConstraint(new string[] { "minprijs", "maxprijs" }) } // met custom constraint
);
app.MapControllerRoute(
    name: "PlantenMetGekendeKleur",
    pattern: "plant/{kleur}",
    defaults: new { controller = "Plant", action = "FindPlantenByKleur" },
    constraints: new { kleur = new KleurenConstraint() } // met custom constraint
);
app.MapControllerRoute(
    name: "PlantenVanEenLeverancier",
    pattern: "leverancier/{levnr}/planten",
    defaults: new { controller = "Plant", action = "FindPlantenByLeverancier" },
    constraints: new { levnr = new MaxRouteConstraint(10) } // enkel integer wordt hier aanvaard
);
app.MapControllerRoute(
    name: "PlantenVanEenSoort",
    pattern: "soort/{soortnaam}/planten",
    defaults: new { controller = "Plant", action = "FindPlantenBySoortNaam" },
    constraints: new { soortnaam = new CompositeRouteConstraint(
        new List<IRouteConstraint>
        {
            new AlphaRouteConstraint(), // enkel letters (hoofd of klein) worden aanvaard hier
            new MinLengthRouteConstraint(3),
            new MaxLengthRouteConstraint(10)
        })
    }
);
app.MapControllerRoute(
    name: "PlantByNr",
    pattern: "Plant/{id}",
    defaults: new { controller = "Plant", action = "Details" },
    constraints: new { id = new IntRouteConstraint() }
);
app.MapControllerRoute(
    name: "AllePlanten",
    pattern: "Plantenlijst",
    defaults: new { controller = "Plant", action = "Index" }
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
).WithStaticAssets();


app.Run();
