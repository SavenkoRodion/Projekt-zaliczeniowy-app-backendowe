using Microsoft.EntityFrameworkCore;
using Wsei.Matches.Application.Services;
using Wsei.Matches.Core.ServiceInterfaces;
using Wsei.Matches.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MatchesDbContext>(
       options => options.UseSqlServer("name=ConnectionStrings:MatchesDb"));
builder.Services.AddScoped<ICountryService, CountryService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
