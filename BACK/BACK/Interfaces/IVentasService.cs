using BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BACK.Interfaces
{
    public interface IVentasService
    {
        Task<Venta> PostVenta(Venta nuevaVenta);

    }
}
