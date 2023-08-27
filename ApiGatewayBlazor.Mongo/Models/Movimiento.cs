using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiGatewayBlazor.Mongo.Models
{
    public class Movimiento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        
        //DATOS PARA LA VENTA:

        [BsonElement("productoID")]
        public int ProductoId { get; set; } 

        [BsonElement("descripcionProducto")]
        public string DescripcionProducto { get; set; } = string.Empty;

        [BsonElement("clienteID")]
        public int ClienteId { get; set; }

        [BsonElement("nombreCliente")]
        public string NombreCliente { get; set; } = string.Empty;

        //DATOS PARA LOS LIKE Y DISLIKE:

        [BsonElement("tipoDeMovimiento")]
        //public TipoMovimiento Tipo { get; set; }
        public string TipoMovimiento { get; internal set; } = string.Empty; 
    }

    //public enum TipoMovimiento 
    //{
    //    like,
    //    Dislike,
    //    Venta
    //}


}
