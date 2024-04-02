using Flyers.Core.Values;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Entidade arquivo
    /// </summary>
    public class ArquivoEntity : BaseEntity
    {
        //Propriedades    
        //Chave fk
        //1-n
        [Display(Name = "Dominio")]
        public int IdDominio { get; set; }
        [JsonIgnore]
        [ForeignKey("IdDominio")]
        public virtual DominioEntity Dominio { get; set; }

        public string Nome { get; set; }
        public byte[] Dados { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; }
        public PastaValue Pasta { get; set; }
        public int Entidade { get; set; }
    }
}
