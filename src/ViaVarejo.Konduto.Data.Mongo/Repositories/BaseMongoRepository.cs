namespace ViaVarejo.Konduto.Data.Mongo.Repositories {
    public class BaseMongoRepository {
        public BaseMongoRepository (string connectionString, string database) {
            MongoClient client = new MongoClient (connectionString);
            IMongoDatabase db = client.GetDatabase (database);
        }
    }
}