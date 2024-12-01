using BACK.Interfaces;
using BACK.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACK.Services
{
    public class VendedoresService : IVendedoresService
    {
        private readonly List<Vendedor> _vendedores;

        // Inyección de la lista con IOptions para utilizar en la propiedad de la clase
        public VendedoresService(IOptions<VendedoresWrapper> vendedoresOptions)
        {
            _vendedores = vendedoresOptions.Value.Vendedores;
        }

        public Task<IEnumerable<Vendedor>> ObtenerTodosLosVendedoresAsync()
        {
            try
            {
                return Task.FromResult(_vendedores.AsEnumerable());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los vendedores.", ex);
            }
        }
    }
}
