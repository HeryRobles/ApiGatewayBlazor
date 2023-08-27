using ApiGatewayBlazor.Mongo.Models;

namespace ApiGatewayBlazor.Mongo.Repositories
{
    public interface IMovimientoCollection
    {
        Task CrearVenta(Movimiento movimiento);
        Task Like(Movimiento movimiento);
        Task DisLike(Movimiento movimiento);
        Task MostrarProductos(Movimiento movimiento);

        Task<List<Movimiento>> MostrarVentas();
        Task<List<Movimiento>> MostrarVentasPorID(string id);
        Task<List<Movimiento>> MostrarProductos();


    }
}
