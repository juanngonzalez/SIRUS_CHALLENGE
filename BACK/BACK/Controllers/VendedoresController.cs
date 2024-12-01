using BACK.Interfaces;
using BACK.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedoresController : ControllerBase
    {
        private readonly IVendedoresService _vendedoresService;

        public VendedoresController(IVendedoresService vendedoresService)
        {
            _vendedoresService = vendedoresService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> ObtenerTodos()
        {
            try
            {
                var vendedores = await _vendedoresService.ObtenerTodosLosVendedoresAsync();

                return Ok(vendedores);
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
