using BrouwerService.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(); // zodat een frontend een rest api call kan doen

builder.Services.AddDbContext<BierlandContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("bierland")));
builder.Services.AddScoped<IBrouwerRepository, BrouwerRepository>();
builder.Services.AddScoped<IFiliaalRepository, FiliaalRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader()); // beetje gevaarlijk op deze manier, maar goed

app.MapControllers();

app.Run();
