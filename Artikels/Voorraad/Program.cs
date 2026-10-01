using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using Voorraad;
using Voorraad.IncomingMessages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("voorraad")));

var factory = new ConnectionFactory();
var connection = await factory.CreateConnectionAsync();
var channel = await connection.CreateChannelAsync();
builder.Services.AddSingleton(channel);

builder.Services.AddHostedService<BerichtOntvanger>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
