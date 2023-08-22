using System.ComponentModel.DataAnnotations;

namespace ApiGatewayBlazor.SqlServer.Models.Entities
{
    public class Cliente
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
    }
}
