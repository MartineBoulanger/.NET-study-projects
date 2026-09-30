using Catalogus;
using Catalogus.Models;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Connection to the database
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("catalogus")));

builder.Services.AddHostedService<BerichtStuurder>();

// Connection to RabbitMQ
var factory = new ConnectionFactory();
var connection = await factory.CreateConnectionAsync();
var channel = await connection.CreateChannelAsync();
builder.Services.AddSingleton(channel);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
