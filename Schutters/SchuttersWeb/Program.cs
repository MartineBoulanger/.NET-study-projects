using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchuttersData.Models;
using SchuttersData.Repositories;
using SchuttersServices;
using SchuttersWeb.Data;

// Gebruik dit command in de Package Manager Console, om de security database aan te maken.
// dotnet ef --startup-project SchuttersWeb/SchuttersWeb.csproj database update --context ApplicationDbContext
// Gelieve de README file te lezen voor meer informatie!

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<SchuttersDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchuttersConnection"),
    x => x.MigrationsAssembly("SchuttersData")));

builder.Services.AddTransient<IClubRepository, SQLClubRepository>();
builder.Services.AddTransient<ILidRepository, SQLLidRepository>();
builder.Services.AddTransient<ClubService>();
builder.Services.AddTransient<LidService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "LedenLijst",
    pattern: "Leden",
    defaults: new { controller = "Lid", action = "Index" }
);

app.MapControllerRoute(
    name: "ZoekLedenLijst",
    pattern: "Leden/Search",
    defaults: new { controller = "Lid", action = "Search" }
);

app.MapControllerRoute(
    name: "ClubsLijst",
    pattern: "Clubs",
    defaults: new { controller = "Club", action = "Index" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
