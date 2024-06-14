using System.Configuration;
using Cart.Models;
using Cart.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<CartDatabaseSettings>(
  builder.Configuration.GetSection(nameof(CartDatabaseSettings)));
// builder.Services.Configure<CartDatabaseSettings>(options =>
// {
//     options.Cåå
// })
builder.Services.AddSingleton<CartDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<CartDatabaseSettings>>().Value);

builder.Services.AddSingleton<CartService>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}