using BIBData.Models;
using BIBData.Repositories;
using BIBServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BIBDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BIBConnection"), x => x.MigrationsAssembly("BIBData")));
builder.Services.AddControllersWithViews();

// repositories
builder.Services.AddTransient<LenerService>();
builder.Services.AddTransient<ILenerRepository, SQLLenerRepository>();
builder.Services.AddTransient<UitleenobjectService>();
builder.Services.AddTransient<IUitleenobjectRepository, SQLUitleenobjectRepository>();
builder.Services.AddTransient<UitleningService>();
builder.Services.AddTransient<IUitleningRepository, SQLUitleningRepository>();
builder.Services.AddTransient<ReserveringService>();
builder.Services.AddTransient<IReserveringRepository, SQLReserveringRepository>();

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
