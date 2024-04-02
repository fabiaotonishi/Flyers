using Flyers.Core.Validations;
using Flyers.Core.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Flyers.Core.Entities
{
    public class ClienteFisicaEntity : ClienteEntity
    {
        [Display(Name = "Cpf")]
        [StringLength(11, MinimumLength = 0, ErrorMessage = "Máximo permitido")]
        [RegularExpression(@"^(\d{11})|(\d{3}\.\d{3}\.\d{3}-\d{2})$", ErrorMessage = "Informe somente números")]
        [CpfValidationAttribute]
        public string Cpf { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Gênero")]
        public GeneroValue Genero { get; set; }
     
    }
}
