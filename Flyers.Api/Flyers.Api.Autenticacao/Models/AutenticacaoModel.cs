using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flyers.Api.Autenticacao.Models
{
    public class Conta
    {
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

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }
    }

    public class Login
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Senha { get; set; }
    }

    public class UsuarioConta
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public IList<string> Permissoes { get; set; }

        public UsuarioConta()
        {
            Permissoes = new List<string>();
        }
    }

    public class UsuarioToken
    {
        public string Token { get; set; }
        public double Expiracao { get; set; }
        public UsuarioConta UsuarioConta { get; set; }
    }
}
