using System.Net;
using ViaVarejo.Konduto.Domain.Caches;
using ViaVarejo.Konduto.Domain.Exceptions;
using ViaVarejo.Konduto.Domain.Interfaces.Proxy;
using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;
using ViaVarejo.Konduto.Domain.Models;

namespace ViaVarejo.Konduto.Domain.Services {
    public class KondutoService {

        private readonly ConfigurationDataCache _configurationDataCache;

        private readonly IKondutoProxy _kondutoProxy;

        public KondutoService (ConfigurationDataCache configurationDataCache, IKondutoProxy kondutoProxy) {
            _configurationDataCache = configurationDataCache;
            _kondutoProxy = kondutoProxy;
        }

        private void CanSendDataToKonduto () {

            //--- obter objeto do cache ou do sql
            ConfigurationData configurationData = _configurationDataCache.GetByKey ("PodeExecutarKonduto");

            //--- verifica se pode executar
            if (configurationData != null || configurationData.Valor.ToLower () != "true") {
                throw new CustomException ("A chave para executar o konduto esta desligada", HttpStatusCode.Unauthorized);
            }
        }

        public void SendData (KondutoData kondutoData) {

            //--- verifica se pode executar
            CanSendDataToKonduto ();

            //--- envia os dados para a konduto

            //--- Fernando - Gravar o resultado da chamada para a konduto no mongo
        }
    }
}