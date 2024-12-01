using BACK.Models;

namespace BACK.Interfaces
{
    public interface IArticulosService
    {
        /// <summary>
        /// Devuelve los articulos filtrados por precio > 0 y deposito = 1
        /// </summary>
        /// <returns>lista de articulos</returns>
        Task<IEnumerable<Articulo>> ObtenerTodosLosArticulosAsync();
    }
}
