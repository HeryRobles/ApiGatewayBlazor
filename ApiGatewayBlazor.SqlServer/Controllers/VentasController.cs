using ApiGatewayBlazor.SqlServer.Models;
using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGatewayBlazor.SqlServer.Controllers
{
    [ApiController, Route("/ventas")]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Venta>>> GetAsync(int id)
        {
            //var venta = await _context.Ventas.FirstOrDefaultAsync(x => x.Id == id);
            var ventas = await _context.Ventas.ToListAsync();

            if (ventas == null) 
            {
                return NotFound();
            }

            return Ok(ventas);
        }

        [HttpPost]

        public async Task<ActionResult> Add([FromBody] Venta venta)
        {
            var ventaAdd = new Venta();
            ventaAdd.Folio = venta.Folio;
            ventaAdd.Fecha = venta.Fecha;   
            ventaAdd.TotalVenta = venta.TotalVenta;

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
