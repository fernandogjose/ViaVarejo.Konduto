using System;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ViaVarejo.Konduto.Domain.Interfaces.MongoRepositories;
using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;
using ViaVarejo.Konduto.Domain.Models;

namespace ViaVarejo.Konduto.Domain.Caches {
    public class ConfigurationDataCache {
        private readonly IMemoryCache _memoryCache;

        private readonly IConfigurationDataMongoRepository _configurationDataMongoRepository;

        private IConfigurationDataSqlRepository _configurationDataSqlRepository;

        public ConfigurationDataCache (IMemoryCache memoryCache, IConfigurationDataMongoRepository configurationDataMongoRepository, IConfigurationDataSqlRepository configurationDataSqlRepository) {
            _memoryCache = memoryCache;
            _configurationDataMongoRepository = configurationDataMongoRepository;
            _configurationDataSqlRepository = configurationDataSqlRepository;
        }

        private string GetByCacheInMemory (string key) {

            //--- recupera do cache e verifica se é null
            string valueCached = _memoryCache.Get<string> (key);
            if (string.IsNullOrEmpty (valueCached)) {
                return valueCached;
            }

            //--- verifica se a data de mudanca já expirou
            return ValidateExpirationDate (valueCached, 15);
        }

        private string GetByCacheInMongo (string key) {

            //--- recupera do cache e verifica se é null
            string valueCached = _configurationDataMongoRepository.GetByKey (key);
            if (string.IsNullOrEmpty (valueCached)) {
                return valueCached;
            }

            //--- verifica se a data de mudanca já expirou
            return ValidateExpirationDate (valueCached, 30);
        }

        private string ValidateExpirationDate (string valueCached, int addMinutes) {
            ConfigurationData configurationData = JsonConvert.DeserializeObject<ConfigurationData> (valueCached);
            return configurationData.DataMudanca.AddMinutes (addMinutes) < DateTime.Now ? "" : valueCached;
        }

        private void AddCache (ConfigurationData configurationData, string key) {
            string valueCached = JsonConvert.SerializeObject (configurationData);
            _memoryCache.Set (key, valueCached);
            _configurationDataMongoRepository.Add (configurationData);
        }

        public ConfigurationData GetByKey (string key) {

            //--- obter da memória
            string response = GetByCacheInMemory (key);
            if (response != null) {
                return JsonConvert.DeserializeObject<ConfigurationData> (response);
            }

            //--- obter do mongo
            response = GetByCacheInMongo (key);
            if (response != null && !string.IsNullOrEmpty (response)) {
                return JsonConvert.DeserializeObject<ConfigurationData> (response);
            }

            //--- se não tem no cache, busca no banco de dados e atualiza o cache
            ConfigurationData configurationData = _configurationDataSqlRepository.GetByKey ("PodeExecutarKonduto");
            AddCache (configurationData, key);

            return configurationData;
        }
    }
}