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
            var articulos = await _articuloService.ObtenerTodosLosArticulosAsync();
            return Ok(articulos);
        }
    }
}
