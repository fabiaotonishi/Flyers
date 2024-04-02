using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Entidade produto
    /// </summary>
    public class ProdutoEntity : BaseEntity
    {
        //Propriedades
        //Chave fk/
        //1-n
        [Display(Name = "Dominio")]
        public int IdDominio { get; set; }
        [JsonIgnore]
        [ForeignKey("IdDominio")]
        public virtual DominioEntity Dominio { get; set; }
        //1-n
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }
        [JsonIgnore]
        [ForeignKey("IdCategoria")]
        public virtual CategoriaEntity Categoria { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [Range(typeof(decimal), "0", "99999999999999999999", ErrorMessage = "Formato inválido")]
        [RegularExpression(@"^(R\$?\s)?(([1-9]\d{0,2}(\.\d{3})*|([1-9]\d*))((\,)\d{2}){1})|([0-9]{0,})$", ErrorMessage = "Formato inválido")]
        [DataType(DataType.Currency, ErrorMessage = "Formato inválido")]
        [DisplayFormat(DataFormatString = "{0:C}", NullDisplayText = "Formato inválido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public bool Destaque { get; set; }

        [NotMapped]
        public ArquivoEntity Imagem { get; set; }

        //Relacionamentos
        //n-n
        public virtual ICollection<OfertaProdutoEntity> OfertaProdutos { get; set; }

        public ProdutoEntity()
        {
            Preco = Convert.ToDecimal("0,00", new CultureInfo("pt-BR"));
        }
    }
}