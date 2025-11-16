using Dominio.Entities;
using Infraestructura.Persistencia;
using Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ColegioDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ColegioRepository>();

// Registrar repositorios
builder.Services.AddScoped<ColegioRepository>();
builder.Services.AddScoped<MateriaRepository>();


builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// Controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ColegioGXC API",
        Version = "v1",
        Description = "API para gestión de colegios, materias y usuarios"
    });
});

var app = builder.Build();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ColegioGXC API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
app.Run();


builder.Services.AddDbContext<ColegioDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<MateriaRepository>();
