using Microsoft.Extensions.Caching.Memory;

namespace ViaVarejo.Konduto.Domain.Services {

    public class CacheService {
        private readonly IMemoryCache _memoryCache;

        public CacheService (IMemoryCache memoryCache) {
            _memoryCache = memoryCache;
        }

        public string GetByKey (string key) {
            //--- Fernando - Criar uma data de expiração para o cache

            //--- obter da memória
            var value = _memoryCache.Get<string> (key);
            if (!string.IsNullOrEmpty (value)) {
                return value;
            }

            //--- obter do mongo

            return value;
        }
    }
}