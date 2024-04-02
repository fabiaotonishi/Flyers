using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Entidade endereco
    /// </summary>
    public class EnderecoEntity : BaseEntity
    {
        //Propriedades
        [Display(Name = "Cep")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        //Relacionamentos
        //1-n
        public virtual ICollection<DominioEntity> Dominios { get; set; }

    }
}
