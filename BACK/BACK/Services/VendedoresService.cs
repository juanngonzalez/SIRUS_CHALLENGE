using BACK.Interfaces;
using BACK.Models;
using Microsoft.Extensions.Options;

namespace BACK.Services
{
    public class VendedoresService : IVendedoresService
    {
        private readonly List<Vendedor> _vendedores;

        public VendedoresService(IOptions<VendedoresWrapper> vendedoresOptions)
        {
            _vendedores = vendedoresOptions.Value.Vendedores;
        }

        public Task<IEnumerable<Vendedor>> ObtenerTodosLosVendedoresAsync()
        {
            return Task.FromResult(_vendedores.AsEnumerable());
        }
    }
}
