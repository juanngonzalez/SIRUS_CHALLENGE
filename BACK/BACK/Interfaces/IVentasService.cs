using BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BACK.Interfaces
{
    public interface IVentasService
    {
        /// <summary>
        /// Envia el formulario de pedido
        /// </summary>
        /// <param name="nuevaVenta">Contenedor para recibir el vendedor y los articulos</param>
        /// <returns>Id de la venta</returns>
        Task<Venta> PostVenta(Venta nuevaVenta);

    }
}
