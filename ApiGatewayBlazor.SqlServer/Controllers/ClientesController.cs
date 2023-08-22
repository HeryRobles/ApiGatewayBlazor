using ApiGatewayBlazor.SqlServer.Models;
using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiGatewayBlazor.SqlServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Cliente cliente)
        {
            var clienteAdd = new Cliente();
            clienteAdd.Name = cliente.Name;

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

