using System;
using System.Collections.ObjectModel;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using ViaVarejo.Konduto.Domain.Interfaces.MongoRepositories;

namespace ViaVarejo.Konduto.Data.Mongo.Repositories {

    public class ConfigurationMongoRepository : BaseMongoRepository, IConfigurationMongoRepository {

        public ConfigurationMongoRepository (string serverName, string database) : base (serverName, database) { }

        public string GetByKey (string key) {
             var dadosConfiguracao = _database.GetCollection<DadosConfiguracao> ("DadosConfiguracao").Find (x => x._id.ToLower () == key.ToLower ()).FirstOrDefault ();
             return dadosConfiguracao == null ? "" : dadosConfiguracao.Valor.ToLower();
            
            // var dadosConfiguracao = _database.GetCollection<BsonDocument> ("DadosConfiguracao").Find ("{'Nome' : " + key + "}");
            // var collection = _database.GetCollection<BsonDocument> ("DadosConfiguracao");
            // var teste = collection.Find (x => x._id.ToLower () == key.ToLower ()).FirstOrDefault() as DadosConfiguracao;

            // var filter = new BsonDocument ("Nome", key);
            // var teste = collection.Find (filter).FirstOrDefault ();

            // var json = JsonConvert.DeserializeObject<DadosConfiguracao> (teste.ToString());
            // return "";
        }
    }

    public class DadosConfiguracao {

        public string _id { get; set; }

        public int IdDadosConfiguracao { get; set; }

        public int IdDadosConfiguracaoAmbiente { get; set; }

        public string Ambiente { get; set; }

        public int IdDadosConfiguracaoAplicacao { get; set; }

        public string Aplicacao { get; set; }

        public int IdDadosConfiguracaoGrupo { get; set; }

        public string Grupo { get; set; }

        public string Nome { get; set; }

        public string Valor { get; set; }

        public DateTime DataMudanca { get; set; }

        public bool FlagEditavel { get; set; }

        public string AlteradoPor { get; set; }
    }
}