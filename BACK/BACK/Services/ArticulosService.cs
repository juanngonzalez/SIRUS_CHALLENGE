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
            try
            {
                // Filtrar y validar los artículos
                var articulosFiltrados = _articulos
                .Where(a => a.Deposito == 1 && a.Precio > 0) // Validar depósito y precio
                .Select(a => new Articulo
                {
                    Codigo = LimpiarCaracteresEspeciales(a.Codigo), // Limpiar caracteres especiales
                    Descripcion = LimpiarCaracteresEspeciales(a.Descripcion), // Limpiar caracteres especiales
                    Precio = a.Precio,
                    Deposito = a.Deposito
                });

                return Task.FromResult(articulosFiltrados.AsEnumerable());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener los articulos.", ex);
            }
        }

        // Método para eliminar caracteres especiales de la descripción
        private string LimpiarCaracteresEspeciales(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                return descripcion;

            // Expresión regular para eliminar caracteres no alfanuméricos, incluyendo los especiales como %
            return Regex.Replace(descripcion, @"[^a-zA-Z0-9\s]", ""); // Eliminar todos los caracteres especiales
        }

    }
}
