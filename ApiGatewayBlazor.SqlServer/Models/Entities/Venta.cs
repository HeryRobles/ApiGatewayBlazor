namespace ApiGatewayBlazor.SqlServer.Models.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }

        public decimal TotalVenta { get; set; }

        public int ClienteId { get; set; }
    }
}
