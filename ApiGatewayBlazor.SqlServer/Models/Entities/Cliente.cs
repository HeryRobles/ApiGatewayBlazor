using System.ComponentModel.DataAnnotations;

namespace ApiGatewayBlazor.SqlServer.Models.Entities
{
    public class Cliente
    {
        [Required]
        public int ClienteId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<Venta>? VentaDetalle { get; set; }

    }
}
