using BACK.Interfaces;
using BACK.Models;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace BACK.Services
{
    public class ArticulosService : IArticulosService
    {
        private readonly List<Articulo> _articulos;

        public ArticulosService(IOptions<ArticulosWrapper> articulosOptions)
        {
            _articulos = articulosOptions.Value.Articulos;
        }

        public Task<IEnumerable<Articulo>> ObtenerTodosLosArticulosAsync()
        {
            // Filtrar y validar los artículos
            var articulosFiltrados = _articulos
                .Where(a => a.Deposito == 1 && a.Precio > 0) // Validar depósito y precio
                .Select(a => new Articulo
                {
                    Codigo = a.Codigo,
                    Descripcion = LimpiarDescripcion(a.Descripcion), // Limpiar caracteres especiales
                    Precio = a.Precio,
                    Deposito = a.Deposito
                });

            return Task.FromResult(articulosFiltrados.AsEnumerable());
        }

        // Método para eliminar caracteres especiales de la descripción
        private string LimpiarDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                return descripcion;

            // Expresión regular para eliminar caracteres no alfanuméricos, incluyendo los especiales como %
            return Regex.Replace(descripcion, @"[^a-zA-Z0-9\s]", ""); // Eliminar todos los caracteres especiales
        }

    }
}
