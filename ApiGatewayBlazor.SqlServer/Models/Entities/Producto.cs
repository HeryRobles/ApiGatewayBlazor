namespace ApiGatewayBlazor.SqlServer.Models.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string DescripcionProducto { get; set; } = string.Empty;
        public decimal ValorUnitario { get; set; } 
        public string UbicacionProducto { get; set; } = string.Empty;

        public List<Venta>? VentaDetalle { get; set; }
    }
}
