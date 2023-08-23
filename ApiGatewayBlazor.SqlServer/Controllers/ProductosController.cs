using ApiGatewayBlazor.SqlServer.Models;
using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGatewayBlazor.SqlServer.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Producto producto)
        {
            var productoAdd = new Producto();
            productoAdd.DescripcionProducto = producto.DescripcionProducto;
            productoAdd.ValorUnitario = producto.ValorUnitario;
            productoAdd.UbicacionProducto = producto.UbicacionProducto;

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProducto(int id, Producto producto)
        //{
        //    if (id != producto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(producto).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// DELETE: api/Productos/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProducto(int id)
        //{
        //    var producto = await _context.Productos.FindAsync(id);
        //    if (producto == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Productos.Remove(producto);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ProductoExists(int id)
        //{
        //    return _context.Productos.Any(p => p.Id == id);
        //}
    }
}
