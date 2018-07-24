using Microsoft.Extensions.Caching.Memory;
using ViaVarejo.Konduto.Domain.Interfaces.MongoRepositories;

namespace ViaVarejo.Konduto.Domain.Services {

    public class CacheService {

        private readonly IMemoryCache _memoryCache;

        private readonly IConfigurationMongoRepository _configurationMongoRepository;

        public CacheService (IMemoryCache memoryCache, IConfigurationMongoRepository configurationMongoRepository) {
            _memoryCache = memoryCache;
            _configurationMongoRepository=configurationMongoRepository;
        }

        public string GetByKey (string key) {
            //--- Fernando - Criar uma data de expiração para o cache

            //--- obter da memória
            string value = _memoryCache.Get<string> (key);
            if (!string.IsNullOrEmpty (value)) {
                return value;
            }

            //--- obter do mongo
            value = _configurationMongoRepository.GetByKey(key);

            return value;
        }
    }
}