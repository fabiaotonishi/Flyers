using Flyers.Core.Interfaces;
using Flyers.Core.Validations;
using Flyers.Core.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flyers.Core.Entities
{
    public class ClienteEntity : BaseEntity
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

        public PessoaValue Pessoa { get; set; }

        public ClienteEntity()
        {
        }
    }
}
