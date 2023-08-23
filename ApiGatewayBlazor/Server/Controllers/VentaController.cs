using ApiGatewayBlazor.Mongo.Models;
using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiGatewayBlazor.SqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly VentaController _dbContext;
        private readonly HttpClient _httpClient;

        public VentaController(VentaController dbContext)
        {
            _dbContext = dbContext;
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarVenta([FromQuery] int ventaId)
        {

            HttpResponseMessage response = await _httpClient.GetAsync($"api/ventas/{ventaId}");

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                Venta venta = JsonConvert.DeserializeObject<Venta>(responseData);

                Movimiento movimiento = new Movimiento
                {
                    ProductoId = venta.ProductoId,
                    DescripcionProducto = venta.DescripcionProducto,
                    ClienteId = venta.ClienteId,
                    NombreCliente = venta.NombreCliente,
                    TipoMovimiento = "Venta" // Set the type of movement
                };


                return Ok("Venta generada exitosamente.");
            }
            else
            {
                return BadRequest("Error fetching venta.");
            }


        }
    }
}
