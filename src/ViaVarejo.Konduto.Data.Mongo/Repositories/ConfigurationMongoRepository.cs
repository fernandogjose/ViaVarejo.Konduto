using ViaVarejo.Konduto.Domain.Interfaces.MongoRepositories;

namespace ViaVarejo.Konduto.Data.Mongo.Repositories {

    public class ConfigurationMongoRepository : BaseMongoRepository, IConfigurationMongoRepository {

        private readonly string _connectionString;

        public ConfigurationMongoRepository (string connectionString, string database) : base (connectionString, database) { }

        public string GetByKey (string key) {
            return "";
        }
    }
}