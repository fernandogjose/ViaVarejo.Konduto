using System;
using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;

namespace ViaVarejo.Konduto.Data.SqlRepositories {

    public class BaseSqlRepository {

        private readonly string _connectionString;

        public BaseSqlRepository (string connectionString) {
            _connectionString = connectionString;
        }

        public string GetConnectionString () {
            return _connectionString;
        }

        public object GetDbValue (string value) {
            if (string.IsNullOrEmpty (value)) {
                return DBNull.Value;
            }

            return value.Trim ();
        }
    }
}