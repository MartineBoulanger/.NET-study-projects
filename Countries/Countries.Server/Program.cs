using Countries.Server.DTOs;
using Countries.Server.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CountriesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddCors();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseCors(builder => builder.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet(
    "/countries",
    async (ICountryRepository repository) =>
    {
        var countries = await repository.GetAll();
        return countries.Select(c => c.ToModel()).ToList();
    }
);
app.MapGet(
    "/top-population/{top}",
    async (int top, ICountryRepository repository) =>
    {
        var countries = await repository.GetTopPopulationCountries(top);
        return countries.Select(c => c.ToModel()).ToList();
    }
);
app.MapGet(
    "/search-country",
    async (string name, ICountryRepository repository) =>
    {
        var countries = await repository.FindByName(name);
        return countries.Select(c => c.ToModel()).ToList();
    }
);

app.MapDelete("/delete-country/{id}", DeleteCountry);

app.Run();

// Medthods for the app.Map...
async Task<IResult> DeleteCountry(int id, ICountryRepository repository)
{
    var country = await repository.Find(id);
    if (country == null)
        return Results.NotFound(id);
    await repository.Delete(country);
    return Results.Ok(country.ToModel());
}
