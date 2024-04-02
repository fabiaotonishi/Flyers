using Flyers.Core.Values;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Flyers.Web.Models
{
    public class Conta
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome não informado", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        [RegularExpression(@"^[.a-zá-úA-ZÁ-Ú0-9_üÜ'\s]+$", ErrorMessage = "Caracteres inválidos")]
        public string Nome { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone não informado", AllowEmptyStrings = false)]
        [StringLength(16, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "Data não informada", AllowEmptyStrings = false)]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Gênero não informado", AllowEmptyStrings = false)]
        public GeneroValue Genero { get; set; }

        [JsonIgnore]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha não informada", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mínimo (8)caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [NotMapped]
        [JsonIgnore]
        [Display(Name = "Confirme a senha")]
        [Required(ErrorMessage = "Senha não informada", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mínimo (8)caracteres")]
        [Compare("Senha", ErrorMessage = "Senha diferente da informada")]
        [DataType(DataType.Password)]
        public string SenhaConfirma { get; set; }
    }

    public class Login
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe o e-mail", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha", AllowEmptyStrings = false)]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Informe uma senha com no mínimo (8) caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool Conectado { get; set; }
    }
}
