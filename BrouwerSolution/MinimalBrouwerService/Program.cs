using Microsoft.EntityFrameworkCore;
using MinimalBrouwerService.Models;
using MinimalBrouwerService.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BierlandContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("bierland")));
builder.Services.AddScoped<IBrouwerRepository, BrouwerRepository>();

builder.Services.AddValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// enkele voorbeelden van minimal API
//app.MapGet("geluk", () => 7);
//app.MapGet("kwadraat/{getal}", (int getal) => getal * getal);
//app.MapGet("/brouwers", async (IBrouwerRepository repository) => await repository.FindAllAsync());
//app.MapGet("/brouwers/{id}", async (int id, IBrouwerRepository repository) => await repository.FindByIdAsync(id) is Brouwer brouwer ? Results.Ok(brouwer) : Results.NotFound());
//app.MapGet("/brouwers/naam", async (string begin, IBrouwerRepository repository) => await repository.FindByBeginNaamAsync(begin));
//app.MapDelete("/brouwers/{id}", VerwijderBrouwer);
//app.MapPost("/brouwers", VoegBrouwerToe);
//app.MapPut("/brouwers/{id}", WijzigBrouwer);

// zorgen voor DRY, dus werken met MapGroup
var groep = app.MapGroup("/brouwers");
groep.MapGet("", async (IBrouwerRepository repository) => await repository.FindAllAsync());
groep.MapGet("{id}", async (int id, IBrouwerRepository repository) => await repository.FindByIdAsync(id) is Brouwer brouwer ? Results.Ok(brouwer) : Results.NotFound());
groep.MapGet("naam", async (string begin, IBrouwerRepository repository) => await repository.FindByBeginNaamAsync(begin));
groep.MapDelete("{id}", VerwijderBrouwer);
groep.MapPost("", VoegBrouwerToe);
groep.MapPut("{id}", WijzigBrouwer);

async Task<IResult> VerwijderBrouwer(int id, IBrouwerRepository repository)
{
    var brouwer = await repository.FindByIdAsync(id);
    if (brouwer == null)
    {
        return Results.NotFound();
    }
    await repository.DeleteAsync(brouwer);
    return Results.Ok();
}

async Task<IResult> VoegBrouwerToe(Brouwer brouwer, IBrouwerRepository repository)
{
    await repository.InsertAsync(brouwer);
    return Results.Created($"/brouwers/{brouwer.Id}", null);
}

async Task<IResult> WijzigBrouwer(int id, Brouwer brouwer, IBrouwerRepository repository)
{
    try
    {
        brouwer.Id = id;
        await repository.UpdateAsync(brouwer);
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

app.Run();
