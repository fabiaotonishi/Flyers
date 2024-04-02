using Flyers.Core.Values;
using Flyers.Core.Extensions;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Entidade usuario
    /// </summary>
    public class UsuarioEntity : BaseEntity
    {
        //Propriedades     
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        public string Nome { get; set; }

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

        [JsonIgnore]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mínimo (8)caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Preenchimento obrigatório", AllowEmptyStrings = false)]
        public PerfilValue Perfil { get; set; }


        [NotMapped]
        public ArquivoEntity Imagem { get; set; }

        public void CriptografaDados()
        {
            Senha = Senha.ToMd5();
        }
    }
}
