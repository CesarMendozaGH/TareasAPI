using Microsoft.EntityFrameworkCore;
using TareasAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("cadenaSQL");
builder.Services.AddDbContext<Bdtareas904Context>(options =>
    options.UseSqlServer(connectionString));

//Definimos la nueva politica de CORS para que la API sea
//accesible para cualquiera
builder.Services.AddCors(options =>
    {

        options.AddPolicy("NuevaPolitica", app =>
        {
            app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    
    
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Activamos la nueva politica

app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
