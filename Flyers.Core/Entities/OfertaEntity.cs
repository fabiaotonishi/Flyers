using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Entidade ofertas
    /// </summary>
    public class OfertaEntity : BaseEntity
    {
        //Propriedades
        //Chave fk
        //1-n
        [Display(Name = "Dominio")]
        public int IdDominio { get; set; }
        [JsonIgnore]
        [ForeignKey("IdDominio")]
        public virtual DominioEntity Dominio { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Display(Name = "Data de início")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Inicio { get; set; }

        [Display(Name = "Data de termino")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Termino { get; set; }

        [NotMapped]
        public ArquivoEntity Imagem { get; set; }

        public OfertaEntity()
        {
            Inicio = DateTime.Today;
            Termino = DateTime.Today.AddDays(30);
        }

        //Relacionamentos
        //n-n
        public virtual ICollection<OfertaProdutoEntity> OfertaProdutos { get; set; }
    }
}
