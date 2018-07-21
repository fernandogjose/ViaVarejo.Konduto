using System;
using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;

namespace ViaVarejo.Konduto.Data.SqlRepositories {

    public class BaseSqlRepository {

        public object GetDbValue(string value){
            if(string.IsNullOrEmpty(value)){
                return DBNull.Value;
            }

            return value.Trim();
        }        
    }
}