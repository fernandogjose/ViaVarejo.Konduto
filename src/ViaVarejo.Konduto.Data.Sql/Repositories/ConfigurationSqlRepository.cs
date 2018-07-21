using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;

namespace ViaVarejo.Konduto.Data.SqlRepositories {

    public class ConfigurationSqlRepository : BaseSqlRepository, IConfigurationSqlRepository {

        private readonly string _connectionString;

        public ConfigurationSqlRepository (string connectionString) {
            _connectionString = connectionString;
        }

        public string GetByKey (string key) {

            //--- Fernando - Criar o método para buscar no banco de dados sql
            return GetDbValue (key).ToString ();
        }
    }
}