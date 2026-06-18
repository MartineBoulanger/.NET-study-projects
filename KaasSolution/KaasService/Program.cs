using KaasService.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddDbContext<KaaslandContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("kaasland")));
builder.Services.AddScoped<IKaasRepository, KaasRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());

app.MapControllers();

app.Run();
