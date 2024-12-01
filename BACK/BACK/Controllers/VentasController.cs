using BACK.Interfaces;
using BACK.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

                return Ok(venta.Id); 
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor.", error = ex.Message });
            }
        }
    }
}
