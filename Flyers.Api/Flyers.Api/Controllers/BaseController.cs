using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Flyers.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        //customizacoes das mensagens de erros da API
        protected ICollection<string> Erros = new List<string>();

        //respostas com tratamentos de erros
        protected ActionResult ApiResposta(object resultado = null)
        {
            if (Valido())
            {
                return Ok(resultado);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        //Data annotations
        protected ActionResult ApiResposta(ModelStateDictionary modelState)
        {
            foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
            {
                //faz o tratamento dos erros
                IncluiErro(erro.ErrorMessage);
            }
            return ApiResposta();
        }

        //Fluente validation
        protected ActionResult ApiResposta(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                //faz o tratamento dos erros
                IncluiErro(erro.ErrorMessage);
            }
            return ApiResposta();
        }

        protected bool Valido()
        {
            return !Erros.Any();
        }

        protected void IncluiErro(string erro)
        {
            Erros.Add(erro);
        }

        protected void RemoveErros()
        {
            Erros.Clear();
        }
    }
}
