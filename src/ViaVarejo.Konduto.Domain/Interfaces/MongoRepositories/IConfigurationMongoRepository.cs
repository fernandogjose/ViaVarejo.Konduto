namespace ViaVarejo.Konduto.Domain.Interfaces.MongoRepositories {

    public interface IConfigurationMongoRepository {

        string GetByKey (string key);
    }
}