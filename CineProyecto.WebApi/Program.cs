using CineProyecto.WebApi.Classes;
using CineProyecto.WebApi.Interfaces.Classes;
using CineProyecto.WebApi.Interfaces.Services;
using CineProyecto.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPeliculasService, PeliculasService>();
builder.Services.AddSingleton<IPeliculasManager, PeliculasManager>();

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