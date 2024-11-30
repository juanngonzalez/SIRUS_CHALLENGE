using BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BACK.Interfaces
{
    public interface IVentasService
    {
        Task<ActionResult<Venta>> PostVenta(Venta nuevaVenta);

    }
}
