using Flyers.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flyers.Core.Validations
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CpfValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var clientePFisica = (ClienteFisicaEntity)validationContext.ObjectInstance;

            if (clientePFisica.Cpf != null)
            {
                var cpfValidacao = new CpfValidation(clientePFisica.Cpf);
                if (!cpfValidacao.Validar())
                {
                    return new ValidationResult("Cpf é inválido");
                }
            }

            //return (clientePFisica.Idade >= 18)
            //    ? ValidationResult.Success
            //    : new ValidationResult("Menor de idade");

            return ValidationResult.Success;
        }
    }
}
