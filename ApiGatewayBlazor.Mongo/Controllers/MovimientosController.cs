using ApiGatewayBlazor.Mongo.Models;
using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiGatewayBlazor.Mongo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosController : ControllerBase
    {
        //Conectar a la base de datos
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        
        //Coleccion = tabla
        private readonly IMongoCollection<Movimiento> _collection;
       
        public MovimientosController()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("ventas");
            //Coleccion = tabla
            _collection = _database.GetCollection<Movimiento>("movimientos");

        }

        [HttpGet]
        public async Task<IActionResult> ConsultarVenta([FromQuery] int ventaId)
        {
            string sqlServerApiUrl = "https://localhost:7152";
            using (HttpClient httpClient = new HttpClient()) 
            {
                HttpResponseMessage response = await 
                    httpClient.GetAsync($"{https://localhost:7152}/ApiGatewayBlazor/SqlServer/Models/Entities/{ventaId}");
                if (response.IsSuccessStatusCode)
                {
                    Venta venta = await.response.Content.ReadAsAsync<Venta>();
                    Movimiento movimiento = new Movimiento
                    {
                        ProductoId = venta.ProductoId,
                        DescripcionProducto = venta.Descripcion,
                        ClienteId = venta.ClienteId,
                        NombreCliente = venta.Name,
                        TipoMovimiento = "Venta"
                    };
                    await _collection.InsertOneAsync(movimiento);
                    return Ok("venta generada");
                }
                else
                {
                    return BadRequest("Error fetching venta.");
                }
              
            }

            
        }

        [HttpPost]
        public async Task<IActionResult> GenerarLike([FromBody] Movimiento like)
        {
            Movimiento likes = new Movimiento();
            likes.Likes = true;

            await _collection.InsertOneAsync(like);

            return Ok("Like generado exitosamente.");
        }

        [HttpPost]
        public async Task<IActionResult> GenerarDislike([FromBody] Movimiento dislike)
        {
            Movimiento dislikes = new Movimiento();
            dislikes.DisLikes = true;

            await _collection.InsertOneAsync(dislike);

            return Ok("Dislike generado exitosamente.");
        }

        //private int likeCount = 0;

        //private void IncrementLikeCount()
        //{
        //    likeCount++;
        //}

        //private void DecrementLikeCount()
        //{
        //    likeCount--;
        //}

        //[HttpPost]
        //public async Task<IActionResult> GenerarVenta([FromBody] Movimiento venta)
        //{
        //    if (venta == null)
        //        return BadRequest();
        //    if (venta.DescripcionProducto == string.Empty)
        //    {
        //        ModelState.AddModelError("descripcionProducto", "La venta no ha sido encontrada");
        //    }
        //    await _collection.InsertOneAsync(venta);
        //    return Ok();
        //}
    }
}





