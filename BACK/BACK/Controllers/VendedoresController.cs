using BACK.Interfaces;
using BACK.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<Articulo>>> ObtenerTodos()
        {
            var vendedores = await _vendedoresService.ObtenerTodosLosVendedoresAsync();
            return Ok(vendedores);
        }
    }
}
