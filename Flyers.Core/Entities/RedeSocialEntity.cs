using Flyers.Core.Values;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Entidade rede social
    /// </summary>
    public class RedeSocialEntity : BaseEntity
    {
        //Propriedades
        //Chave fk
        //1-n
        [Display(Name = "Dominio")]
        public int IdDominio { get; set; }
        [JsonIgnore]
        [ForeignKey("IdDominio")]
        public virtual DominioEntity Dominio { get; set; }

        [Display(Name = "Canal")]        
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        public CanalValue Canal { get; set; }

        [Display(Name = "Endereço do canal (URL)")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(@"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$", ErrorMessage = "Url inválido")]
        [DataType(DataType.Url, ErrorMessage = "Url inválido")]
        public string Url { get; set; }
    }
}
