using System;

namespace ViaVarejo.Konduto.Domain.Models {
    public class ConfigurationData {
        
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