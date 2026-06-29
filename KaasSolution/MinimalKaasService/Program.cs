using Microsoft.EntityFrameworkCore;
using MinimalKaasService.Models;
using MinimalKaasService.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddValidation();

builder.Services.AddDbContext<KaaslandContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("kaasland")));
builder.Services.AddScoped<IKaasRepository, KaasRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

var groep = app.MapGroup("kazen");
groep.MapGet("", async (IKaasRepository repository) => await repository.FindAllAsync());
groep.MapGet("{id}", async (int id, IKaasRepository repository) => await repository.FindByIdAsync(id) is Kaas kaas ? Results.Ok(kaas) : Results.NotFound());
groep.MapGet("smaken", async (string smaak, IKaasRepository repository) => await repository.FindBySmaakAsync(smaak));
groep.MapPut("{id}", WijzigKaas);

async Task<IResult> WijzigKaas(int id, Kaas kaas, IKaasRepository repository)
{
    try
    {
        kaas.Id = id;
        await repository.UpdateAsync(kaas);
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
