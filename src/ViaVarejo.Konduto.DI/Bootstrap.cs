using Microsoft.Extensions.DependencyInjection;
using ViaVarejo.Konduto.Data.Mongo.Repositories;
using ViaVarejo.Konduto.Data.SqlRepositories;
using ViaVarejo.Konduto.Domain.Interfaces.MongoRepositories;
using ViaVarejo.Konduto.Domain.Interfaces.Proxy;
using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;
using ViaVarejo.Konduto.Domain.Services;
using ViaVarejo.Konduto.Proxy;

namespace ViaVarejo.Konduto.DI {
    public class Bootstrap {
        public static void Configure (IServiceCollection services, string connectionStringSql, string connectionStringMongo, string database) {

            //--- Services
            services.AddSingleton<KondutoService> ();
            services.AddSingleton<CacheService> ();

            //--- Proxy
            services.AddSingleton<IKondutoProxy, KondutoProxy> ();

            //--- Sql Repositories
            services.AddSingleton<IConfigurationSqlRepository> (p => new ConfigurationSqlRepository (connectionStringSql));

            //--- Mongo Repositories
            services.AddSingleton<IConfigurationMongoRepository> (p => new ConfigurationMongoRepository (connectionStringMongo, database));
        }
    }
}