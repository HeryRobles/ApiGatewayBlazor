using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApiGatewayBlazor.Shared; // Asegúrate de tener el namespace correcto
using Microsoft.EntityFrameworkCore;

namespace ApiGatewayBlazor.SqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly CatalogosDbSql _dbContext;

        public VentaController(CatalogosDbSql dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("RealizarVenta")]
        public async Task<IActionResult> RealizarVenta([FromBody] VentaModel venta)
        {
            try
            {
                // Agregar lógica para registrar la venta en la base de datos
                _dbContext.Ventas.Add(venta);
                await _dbContext.SaveChangesAsync();

                return Ok("Venta registrada exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al registrar la venta: {ex.Message}");
            }
        }
    }
}
