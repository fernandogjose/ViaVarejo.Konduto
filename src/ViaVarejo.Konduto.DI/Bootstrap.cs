using Microsoft.Extensions.DependencyInjection;
using ViaVarejo.Konduto.Data.SqlRepositories;
using ViaVarejo.Konduto.Domain.Interfaces.Proxy;
using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;
using ViaVarejo.Konduto.Domain.Services;
using ViaVarejo.Konduto.Proxy;

namespace ViaVarejo.Konduto.DI {
    public class Bootstrap {
        public static void Configure (IServiceCollection services) {

            //--- Services
            services.AddSingleton<KondutoService> ();
            services.AddSingleton<CacheService> ();

            //--- Proxy
            services.AddSingleton<IKondutoProxy, KondutoProxy> ();

            //--- Sql Repositories
            services.AddSingleton<IConfigurationSqlRepository, ConfigurationSqlRepository> ();
        }
    }
}