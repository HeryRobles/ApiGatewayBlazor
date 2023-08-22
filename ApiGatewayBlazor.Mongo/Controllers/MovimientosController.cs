using ApiGatewayBlazor.Mongo.Models;
using ApiGatewayBlazor.Mongo.Services;
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
        public ActionResult<IEnumerable<Movimiento>> GetMovimientos()
        {
            try
            {
                var movimientos = _collection.Find(m => true).ToList();
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("likes")]
        public ActionResult<Movimiento> AddLikeDislike(LikeDislike likeDislike)
        {
            try
            {
                var movimiento = new Movimiento
                {
                    ClienteId = likeDislike.ClienteId,
                    ProductoId = likeDislike.ProductoId,
                    TipoMovimiento = TipoMovimiento.Like
                };

                _collection.InsertOne(movimiento);
                return CreatedAtAction(nameof(GetMovimientos), new { id = movimiento.Id }, movimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("dislikes")]
        public ActionResult<Movimiento> AddDislike(LikeDislike likeDislike)
        {
            try
            {
                var movimiento = new Movimiento
                {
                    ClienteId = likeDislike.ClienteId,
                    ProductoId = likeDislike.ProductoId,
                    TipoMovimiento = TipoMovimiento.Dislike
                };

                _collection.InsertOne(movimiento);
                return CreatedAtAction(nameof(GetMovimientos), new { id = movimiento.Id }, movimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("ventas")]
        public ActionResult<Movimiento> AddVenta(Venta venta)
        {
            try
            {
                var movimiento = new Movimiento
                {
                    ClienteId = venta.ClienteId,
                    ProductoId = venta.ProductoId,
                    TipoMovimiento = TipoMovimiento.Venta
                };

                _collection.InsertOne(movimiento);
                return CreatedAtAction(nameof(GetMovimientos), new { id = movimiento.Id }, movimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}




