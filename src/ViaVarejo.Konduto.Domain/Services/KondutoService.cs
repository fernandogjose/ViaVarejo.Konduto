using System.Net;
using ViaVarejo.Konduto.Domain.Exceptions;
using ViaVarejo.Konduto.Domain.Interfaces.Proxy;
using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;
using ViaVarejo.Konduto.Domain.Models;

namespace ViaVarejo.Konduto.Domain.Services {
    public class KondutoService {
        
        private readonly CacheService _cacheService;

        private IConfigurationSqlRepository _configurationSqlRepository;
        
        private readonly IKondutoProxy _kondutoProxy;

        public KondutoService (CacheService cacheService, IConfigurationSqlRepository configurationSqlRepository, IKondutoProxy kondutoProxy) {
            _cacheService = cacheService;
            _configurationSqlRepository = configurationSqlRepository;
            _kondutoProxy = kondutoProxy;
        }

        private void CanSendDataToKonduto () {

            //--- obtem a chave do cache de memoria ou mongo
            string canSendDataToKonduto = _cacheService.GetByKey ("PodeExecutarKonduto");

            //--- caso não esteja no mongo busca no banco de dados
            if (string.IsNullOrEmpty (canSendDataToKonduto)) {
                canSendDataToKonduto = _configurationSqlRepository.GetByKey ("PodeExecutarKonduto");
            }

            //--- verifica se pode executar
            if (string.IsNullOrEmpty (canSendDataToKonduto) || canSendDataToKonduto.ToLower () != "true") {
                throw new CustomException("A chave para executar o konduto esta desligada", HttpStatusCode.Unauthorized);
            }
        }

        public void SendData(KondutoData kondutoData){
            
            //--- verifica se pode executar
            CanSendDataToKonduto();

            //--- envia os dados para a konduto


            //--- Fernando - Gravar o resultado da chamada para a konduto no mongo
        }
    }
}