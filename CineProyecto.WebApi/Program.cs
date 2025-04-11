using CineProyecto.WebApi.Controllers;
using CineProyecto.WebApi.Interfaces.Services;
using CineProyecto.WebApi.Models.Db;
using CineProyecto.WebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgresContext>(options => { options.UseNpgsql(builder.Configuration.GetConnectionString("dataBase")); });
builder.Services.AddScoped<IPeliculasService, PeliculasService>();

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