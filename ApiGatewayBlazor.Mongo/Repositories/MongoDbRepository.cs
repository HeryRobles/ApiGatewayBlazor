using MongoDB.Driver;

namespace ApiGatewayBlazor.Mongo.Repositories
{
    public class MongoDbRepository
    {
        public MongoClient _client;
        public IMongoDatabase _db;
        public MongoDbRepository()
        {
            _client = new  MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("ventas");
        }
    }
}
 