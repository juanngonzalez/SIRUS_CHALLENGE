using BACK.Interfaces;
using BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticulosService _articuloService;

        public ArticulosController(IArticulosService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> ObtenerTodos()
        {
            try
            {
                var articulos = await _articuloService.ObtenerTodosLosArticulosAsync();
                return Ok(articulos);
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
