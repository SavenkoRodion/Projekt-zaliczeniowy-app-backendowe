using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IStartupSetup startupSetup = new StartupSetup();

startupSetup.AddDbContexts(builder.Services, "name=ConnectionStrings:MatchesDb");
startupSetup.AddServicesToInterfaces(builder.Services);
startupSetup.AddRepositoriesToInterfaces(builder.Services);
startupSetup.AddMapper(builder.Services);

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

await app.RunAsync();
