using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiGatewayBlazor.Mongo.Models
{
    public class Movimiento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("productoID")]
        public int ProductoId { get; set; } /*=string.Empty;*/

        [BsonElement("descripcionProducto")]
        public string DescripcionProducto { get; set; } = string.Empty;

        [BsonElement("tipoDeMovimiento")]
        public string TipoDeMovimiento { get; set; } = string.Empty;

        [BsonElement("clienteID")]
        public int ClienteId { get; set; } /*= string.Empty;
*/
        [BsonElement("nombreCliente")]
        public string NombreCliente { get; set; } = string.Empty;
    }
}
