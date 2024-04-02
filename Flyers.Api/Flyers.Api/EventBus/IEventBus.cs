using Flyers.Api.EventBus.IntegrationEvents;
using System.Threading.Tasks;
using System;

namespace Flyers.Api.EventBus
{
    public interface IEventBus : IDisposable
    {
        bool IsConnected { get; }

        /*
         * implementacao pub/sub(publicar e assinar) 
         * processo assincrono 
         */
        void Publish<T>(T integrationEvent)
            where T : BaseIntegrationEvent;

        Task PublishAsync<T>(T integrationEvent)
            where T : BaseIntegrationEvent;

        void Subscribe<T>(string subscriptionId, Action<T> onMenssage)
            where T : class;

        Task SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMenssage)
            where T : class;

        /*
         * implementacao rpc(remote procedure call)
         * processo sincrono 
         * espera a resposta
         */
        TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : BaseIntegrationEvent 
            where TResponse : BaseMessageEvent;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : BaseIntegrationEvent
            where TResponse : BaseMessageEvent;

        IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : BaseIntegrationEvent
            where TResponse : BaseMessageEvent;

        Task<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : BaseIntegrationEvent
            where TResponse : BaseMessageEvent;

    }
}