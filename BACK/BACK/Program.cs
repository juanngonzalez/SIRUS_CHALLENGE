using System.Text.Json;
using BACK.Interfaces;
using BACK.Models;
using BACK.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173")  // Permitir solicitudes desde el frontend local
              .AllowAnyMethod()  // Permitir cualquier método (GET, POST, etc.)
              .AllowAnyHeader(); // Permitir cualquier cabecera
    });
});

// Leer el JSON
var jsonPathArticulos = Path.Combine(Directory.GetCurrentDirectory(), "data", "articulos.json");
var jsonPathVendedores = Path.Combine(Directory.GetCurrentDirectory(), "data", "vendedores.json");

var jsonArticulos = File.ReadAllText(jsonPathArticulos);
var jsonVendedores = File.ReadAllText(jsonPathVendedores);

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};
var articulosWrapper = JsonSerializer.Deserialize<ArticulosWrapper>(jsonArticulos, options);
var vendedoresWrapper = JsonSerializer.Deserialize<VendedoresWrapper>(jsonVendedores, options);

builder.Services.Configure<ArticulosWrapper>(opt =>
{
    if (articulosWrapper != null)
    {
        opt.Articulos = articulosWrapper.Articulos;
    }
});
builder.Services.Configure<VendedoresWrapper>(opt =>
{
    if (vendedoresWrapper != null)
    {
        opt.Vendedores = vendedoresWrapper.Vendedores;
    }
});

// Configurar los servicios
builder.Services.AddSingleton<IArticulosService, ArticulosService>();
builder.Services.AddSingleton<IVendedoresService, VendedoresService>();
builder.Services.AddSingleton<IVentasService, VentasService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar la política de CORS antes de usar autorización o cualquier otro middleware
app.UseCors("AllowLocalhost");  // Aplica la política de CORS

app.UseAuthorization();

app.MapControllers();

app.Run();


