using ApiGatewayBlazor.Mongo.Models;
using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
        public async Task<IActionResult> ObtenerVentas()
        {
            var ventas = await _collection.FindAsync();
            return Ok(ventas);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTipoDeMovimiento(TipoMovimiento tipoMovimiento)
        {
            await _collection.(tipoMovimiento);
            return Ok();
        }

        [HttpGet]
        [Route("ProductosPopulares")]
        public IActionResult ProductosPopulares()
        {
            var productosPopulares = _collection
                .Find(movimiento => movimiento.TipoMovimiento == "Venta")
                .GroupBy(movimiento => movimiento.ProductoId)
                .Select(group => new
                {
                    ProductoId = group.Key,
                    TotalLikes = group.Sum(movimiento => movimiento.Likes)
                })
                .OrderByDescending(group => group.TotalLikes)
                .ToList();

            return Ok(productosPopulares);
        }

        [HttpPost]
        public async Task<IActionResult> GenerarLike([FromBody] Movimiento like)
        {
            Movimiento likes = new Movimiento();
            likes.TipoMovimiento = "Like";

            await _collection.InsertOneAsync(like);

            return Ok("Like generado exitosamente.");
        }

        [HttpPost]
        public async Task<IActionResult> GenerarDislike([FromBody] Movimiento dislike)
        {
            Movimiento dislikes = new Movimiento();
            dislikes.TipoMovimiento = "No me gusta";

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





