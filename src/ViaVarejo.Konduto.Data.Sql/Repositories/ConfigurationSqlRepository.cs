using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;

namespace ViaVarejo.Konduto.Data.SqlRepositories {

    public class ConfigurationSqlRepository : IConfigurationSqlRepository {

        private readonly string _connectionString;

        public ConfigurationSqlRepository (string connectionString) {
            _connectionString = connectionString;
        }

        public string GetByKey (string key) {
            return _connectionString;
        }
    }
}