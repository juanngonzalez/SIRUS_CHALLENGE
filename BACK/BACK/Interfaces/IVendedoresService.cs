using BACK.Models;

namespace BACK.Interfaces
{
    public interface IVendedoresService
    {
        /// <summary>
        /// Devuelve todos los vendedores
        /// </summary>
        /// <returns>lista de vendedores</returns>
        Task<IEnumerable<Vendedor>> ObtenerTodosLosVendedoresAsync();

    }
}
