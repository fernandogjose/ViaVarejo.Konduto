using ViaVarejo.Konduto.Domain.Models;

namespace ViaVarejo.Konduto.Domain.Interfaces.MongoRepositories {

    public interface IConfigurationDataMongoRepository {

        string GetByKey (string key);

        void Add (ConfigurationData configurationDataRequest);
    }
}