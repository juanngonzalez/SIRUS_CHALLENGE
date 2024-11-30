using BACK.Models;

namespace BACK.Interfaces
{
    public interface IArticulosService
    {
        Task<IEnumerable<Articulo>> ObtenerTodosLosArticulosAsync();
    }
}
