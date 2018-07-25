using Microsoft.Extensions.DependencyInjection;
using ViaVarejo.Konduto.Data.Mongo.Repositories;
using ViaVarejo.Konduto.Data.SqlRepositories;
using ViaVarejo.Konduto.Domain.Caches;
using ViaVarejo.Konduto.Domain.Interfaces.MongoRepositories;
using ViaVarejo.Konduto.Domain.Interfaces.Proxy;
using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;
using ViaVarejo.Konduto.Domain.Models;
using ViaVarejo.Konduto.Domain.Services;
using ViaVarejo.Konduto.Proxy;

namespace ViaVarejo.Konduto.DI {
    public class Bootstrap {
        public static void Configure (IServiceCollection services, string connectionStringSql, string connectionStringMongo, string database) {

            //--- Services
            services.AddSingleton<KondutoService> ();
            services.AddSingleton<ConfigurationDataCache> ();

            //--- Proxy
            services.AddSingleton<IKondutoProxy, KondutoProxy> ();

            //--- Sql Repositories
            services.AddSingleton<IConfigurationDataSqlRepository> (p => new ConfigurationDataSqlRepository (connectionStringSql));

            //--- Mongo Repositories
            services.AddSingleton<IConfigurationDataMongoRepository> (p => new ConfigurationDataMongoRepository (connectionStringMongo, database));
        }
    }
}