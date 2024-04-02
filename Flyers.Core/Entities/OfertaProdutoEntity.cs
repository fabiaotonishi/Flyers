using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Entidade produtos da oferta
    /// </summary>
    public class OfertaProdutoEntity : BaseEntity
    {
        //Propriedades
        //Chave fk
        //n-n
        [Display(Name = "Oferta")]
        public int IdOferta { get; set; }
        [JsonIgnore]
        [ForeignKey("IdOferta")]
        public virtual OfertaEntity Oferta { get; set; }

        [Display(Name = "Produto")]
        public int IdProduto { get; set; }
        [JsonIgnore]
        [ForeignKey("IdProduto")]
        public virtual ProdutoEntity Produto { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [Range(typeof(decimal), "0", "99999999999999999999", ErrorMessage = "Formato inválido")]
        [RegularExpression(@"^(R\$?\s)?(([1-9]\d{0,2}(\.\d{3})*|([1-9]\d*))((\,)\d{2}){1})|([0-9]{0,})$", ErrorMessage = "Formato inválido")]
        [DataType(DataType.Currency, ErrorMessage = "Formato inválido")]
        [DisplayFormat(DataFormatString = "{0:C}", NullDisplayText = "Formato inválido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Display(Name = "Desconto (%)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        [RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?$", ErrorMessage = "Formato inválido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Desconto { get; set; }

        [Display(Name = "Preço com desconto")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [Range(typeof(decimal), "0", "99999999999999999999", ErrorMessage = "Formato inválido")]
        [RegularExpression(@"^(R\$?\s)?(([1-9]\d{0,2}(\.\d{3})*|([1-9]\d*))((\,)\d{2}){1})|([0-9]{0,})$", ErrorMessage = "Formato inválido")]
        [DataType(DataType.Currency, ErrorMessage = "Formato inválido")]
        [DisplayFormat(DataFormatString = "{0:C}", NullDisplayText = "Formato inválido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoDesconto { get; private set; }

        public OfertaProdutoEntity()
        {
            //PrecoDesconto = Preco - Desconto * Preco / 100;
        }

        public decimal CalculaPrecoComDesconto() {
            PrecoDesconto = Preco - Desconto * Preco / 100;
            return PrecoDesconto;
        }
    }
}
