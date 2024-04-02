using Flyers.Core.Entities;
using Newtonsoft.Json;

namespace Flyers.Core.Dtos.Viacep
{
    public class CepViacepDto
    {
        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("unidade")]
        public string Unidade { get; set; }

        [JsonProperty("ibge")]
        public string Ibge { get; set; }

        [JsonProperty("gia")]
        public string Gia { get; set; }

        [JsonProperty("ddd")]
        public string Ddd { get; set; }

        [JsonProperty("siafi")]
        public string Siafi { get; set; }

        public EnderecoEntity ObtemEndereco()
        {
            return new EnderecoEntity
            {
                Cep = this.Cep,
                Cidade = this.Localidade,
                Uf = this.Uf,
                Bairro = this.Bairro ?? "",
                Logradouro = this.Logradouro ?? "",
                Complemento = this.Complemento
            };
        }
    }
}