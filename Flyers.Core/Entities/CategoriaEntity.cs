using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Entidade categoria
    /// </summary>
    public class CategoriaEntity : BaseEntity
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [NotMapped]
        public ArquivoEntity Imagem { get; set; }

        //Relacionamentos
        //1-n
        public virtual ICollection<ProdutoEntity> Produtos { get; set; }

        public CategoriaEntity()
        {
        }
    }
}
