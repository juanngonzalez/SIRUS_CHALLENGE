using BACK.Interfaces;
using BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IVentasService _ventasService;

        public VentasController(IVentasService ventasService)
        {
            _ventasService = ventasService;
        }

        [HttpPost]
        public async Task<ActionResult> PostVenta([FromBody] Venta nuevaVenta)
        {
            if (nuevaVenta == null)
            {
                return BadRequest("Los datos de la venta son inválidos.");
            }

            try
            {
                var venta = await _ventasService.PostVenta(nuevaVenta);
                return Ok(venta.Value.Id); 

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
