using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchuttersWeb.Data;
using SchuttersData.Models;
using SchuttersData.Repositories;
using SchuttersServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<SchuttersDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchuttersConnection"), x => x.MigrationsAssembly("SchuttersData")));

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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
