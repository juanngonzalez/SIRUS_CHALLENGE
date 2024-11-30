using BACK.Interfaces;
using BACK.Models;
using Microsoft.Extensions.Options;

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
            return Task.FromResult(_articulos.Where(a => a.Deposito == 1).AsEnumerable());
        }
    }
}

