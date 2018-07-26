using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;
using ViaVarejo.Konduto.Domain.Models;

namespace ViaVarejo.Konduto.Data.SqlRepositories {

    public class ConfigurationDataSqlRepository : BaseSqlRepository, IConfigurationDataSqlRepository {

        private string GetByKeySql = "SELECT Nome, Valor FROM DadosConfiguracao WHERE Nome = @Nome";

        public ConfigurationDataSqlRepository (string connectionString) : base (connectionString) { }

        public ConfigurationData GetByKey (string key) {

            ConfigurationData configurationDataResponse = new ConfigurationData ();

            using (SqlConnection conn = new SqlConnection (GetConnectionString ())) {
                using (var cmd = new SqlCommand ()) {
                    cmd.Connection = conn;
                    cmd.CommandText = GetByKeySql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@Nome", GetDbValue (key));

                    conn.Open ();
                    using (DbDataReader dr = cmd.ExecuteReader ()) {
                        if (dr.Read ()) {
                            configurationDataResponse._id = dr["Nome"].ToString ().ToUpper ();
                            configurationDataResponse.Nome = dr["Nome"].ToString ();
                            configurationDataResponse.Valor = dr["Valor"].ToString ();
                            configurationDataResponse.DataMudanca = DateTime.Now;
                        }
                    }
                }
            }

            return configurationDataResponse;
        }
    }
}