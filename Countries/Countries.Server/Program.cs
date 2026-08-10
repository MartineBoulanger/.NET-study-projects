using Countries.Server.DTOs;
using Countries.Server.Models;
using Countries.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);

string pathCountryFlags = "c:\\data";
if (!string.IsNullOrWhiteSpace(builder.Configuration.GetValue<string>("CountryFlags")))
    pathCountryFlags = builder.Configuration.GetValue<string>("CountryFlags");

builder.Services.AddDbContext<CountriesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
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
app.MapGet(
    "/country/{id}",
    async (int id, ICountryRepository repository) =>
        await repository.Find(id) is Country country
            ? Results.Ok(country.ToModel())
            : Results.NotFound(id)
);
app.MapGet("/get-flag/{id}", async (int id, ICountryRepository repository) =>
{
    //var image = Path.Combine(pathCountryFlags!, $"{id}.png");
    //if (File.Exists(image))
    //    return Results.File(image);
    //else
    //    return Results.NotFound(id);
    var image = await repository.GetFlag(id);
    if (image == null || image.Length == 0)
        return Results.NotFound(id);
    return Results.File(image);
});
app.MapGet("/country/{id}/languages", async (int id, ILanguageRepository repository) =>
{
    var languages = await repository.LanguagesFromCountry(id);
    return languages.Select(l => l.ToModel()).ToList();
});

app.MapDelete("/delete-country/{id}", DeleteCountry);
app.MapPost("/country", AddCountry);
app.MapPost("/findcountryidbyname", FindCountryIdByName);
app.MapPost("/upload-flag/{id}", UploadFlag);
app.MapPut("/country/{id}", UpdateCountry);

app.Run();

// Medthods for the app.Map...
async Task<IResult> DeleteCountry(int id, ICountryRepository repository)
{
    var country = await repository.Find(id);
    if (country == null)
        return Results.NotFound(id);
    await repository.Delete(country);
    //string path = Path.Combine(pathCountryFlags!, $"{id}.png");
    //if (File.Exists(path))
    //    File.Delete(path);
    return Results.Ok(country.ToModel());
}
async Task<IResult> AddCountry(OnlyCountryModel onlyCountryModel, ICountryRepository repository)
{
    if (!MiniValidator.TryValidate(onlyCountryModel, out var errors))
        return Results.BadRequest(errors);
    var country = new Country()
    {
        Id = 0,
        Capital = onlyCountryModel.Capital,
        Name = onlyCountryModel.Name,
        Population = onlyCountryModel.Population,
    };
    await repository.Insert(country);
    return Results.Created($"country/{country.Id}", null);
}
async Task<IResult> FindCountryIdByName(CountryNameModel model, ICountryRepository repository)
{
    var id = await repository.FindCountryIdByName(model.CountryName);
    return Results.Ok(id);
}
async Task<IResult> UpdateCountry(int id, CountryModel countryModel, ICountryRepository repository)
{
    if (!MiniValidator.TryValidate(countryModel, out var errors))
        return Results.BadRequest(errors);
    try
    {
        var country = new Country()
        {
            Id = countryModel.Id,
            Capital = countryModel.Capital,
            Name = countryModel.Name,
            Population = countryModel.Population,
        };
        await repository.Update(country);
        return Results.Ok();
    }
    catch (DbUpdateConcurrencyException)
    {
        return Results.NotFound();
    }
    catch
    {
        return Results.Problem();
    }
}
async Task<IResult> UploadFlag(int id, IFormFile file, ICountryRepository repository)
{
    try
    {
        string result = string.Empty;
        if (file.ContentType != "image/png")
        {

            return Results.Problem($"Enkel filetype .png is toegelaten.");
        }
        long size = file.Length;
        if (size > (2 * 1024 * 1024))
            return Results.Problem("Het bestand is groter dan 2MB");
        //string path = Path.Combine(pathCountryFlags!, $"{id}.png");
        //try
        //{
        //    using var stream = new FileStream(path, FileMode.Create);
        //    await file.CopyToAsync(stream);
        //    return Results.Ok(result);
        //}
        //catch (Exception ex)
        //{
        //    return Results.Problem(ex.Message);
        //}
        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        await repository.UploadFlag(id, memoryStream.ToArray());
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.Problem();
    }
}