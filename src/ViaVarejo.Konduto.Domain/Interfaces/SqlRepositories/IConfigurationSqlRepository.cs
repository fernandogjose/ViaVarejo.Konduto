namespace ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories {

    public interface IConfigurationSqlRepository {

        string GetByKey (string key);
    }
}