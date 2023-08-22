namespace ApiGatewayBlazor.Mongo.Services
{
    public interface ILikeService
    {
        Task<int> ContarMeGusta();
        Task<int> ContarNoMeGusta();
    }
}
