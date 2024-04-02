using FluentValidation.Results;
using Flyers.Api.Application;

namespace Flyers.Api.EventBus.IntegrationEvents
{
    public class MensagemIntegrationEvent : Mensagem
    {
        public ValidationResult ValidationResult { get; set; }

        public MensagemIntegrationEvent(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

    }
}
