using BACK.Models;

namespace BACK.Interfaces
{
    public interface IVendedoresService
    {
        Task<IEnumerable<Vendedor>> ObtenerTodosLosVendedoresAsync();

    }
}
