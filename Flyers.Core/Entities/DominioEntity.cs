using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Entidade dominio
    /// </summary>
    public class DominioEntity : BaseEntity
    {
        //Propriedades
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [StringLength(16, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "What´s App")]
        [StringLength(16, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        [DataType(DataType.PhoneNumber)]
        public string Whatsapp { get; set; }

        [Display(Name = "Vídeo institucional (URL)")]
        [RegularExpression(@"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$", ErrorMessage = "Url inválido")]
        [DataType(DataType.Url, ErrorMessage = "Url inválido")]
        public string Video { get; set; }

        //Chave fk
        //1-n
        [Display(Name = "Endereco")]
        public int? IdEndereco { get; set; }
        [JsonIgnore]
        [ForeignKey("IdEndereco")]
        public virtual EnderecoEntity Endereco { get; set; }

        [NotMapped]
        public virtual ArquivoEntity Imagem { get; set; }

        //Relacionamentos
        //1-n
        public virtual ICollection<ArquivoEntity> Arquivos { get; set; }
        public virtual ICollection<ProdutoEntity> Produtos { get; set; }
        public virtual ICollection<OfertaEntity> Ofertas { get; set; }
        public virtual ICollection<RedeSocialEntity> RedeSociais { get; set; }
    }
}
