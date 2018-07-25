using ViaVarejo.Konduto.Domain.Models;

namespace ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories {

    public interface IConfigurationDataSqlRepository {

        ConfigurationData GetByKey (string key);
    }
}