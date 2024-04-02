using System;
using System.Threading.Tasks;
using EasyNetQ;
using Polly;
using RabbitMQ.Client.Exceptions;
using Flyers.Api.EventBus.IntegrationEvents;

namespace Flyers.Api.EventBus
{
    public class RabbitMQEventBus : IEventBus
    {
        //Implementacao para o RabbitMQ com o EasyNetQ
        private IBus _bus;        
        private readonly string _conexaoRabbitMQ;

        public bool IsConnected => _bus?.Advanced.IsConnected ?? false;

        public RabbitMQEventBus(string conexaoRabbitMQ)
        {
            _conexaoRabbitMQ = conexaoRabbitMQ;
            TryConnect();
        }

        private void TryConnect()
        {
            if (IsConnected)
            {
                return;
            }
            //resiliencia do servico com Polly quando nao tiver conexao
            var policy = Policy.Handle<EasyNetQException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(3, tentativa => TimeSpan.FromSeconds(Math.Pow(2, tentativa)));

            //inicia a fila de mensagens
            _bus = RabbitHutch.CreateBus(_conexaoRabbitMQ);
        }


        public void Dispose()
        {
            _bus.Dispose();
        }

        public void Publish<T>(T mensagem) where T : BaseIntegrationEvent
        {
            TryConnect();
            _bus.PubSub.Publish(mensagem);
        }

        public async Task PublishAsync<T>(T mensagem) where T : BaseIntegrationEvent
        {
            TryConnect();
            await _bus.PubSub.PublishAsync(mensagem);
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMenssage) where T : class
        {
            TryConnect();
            _bus.PubSub.Subscribe(subscriptionId, onMenssage);
        }

        public async Task SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMenssage) where T : class
        {
            TryConnect();
            await _bus.PubSub.SubscribeAsync(subscriptionId, onMenssage);            
        }

        public TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : BaseIntegrationEvent
            where TResponse : BaseMessageEvent
        {
            TryConnect();
            return _bus.Rpc.Request<TRequest, TResponse>(request);
        }

        public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : BaseIntegrationEvent
            where TResponse : BaseMessageEvent
        {
            TryConnect();
            return await _bus.Rpc.RequestAsync<TRequest, TResponse>(request);
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : BaseIntegrationEvent
            where TResponse : BaseMessageEvent
        {
            TryConnect();
            return _bus.Rpc.Respond(responder);

        }

        public async Task<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : BaseIntegrationEvent
            where TResponse : BaseMessageEvent
        {
            TryConnect();
            return await _bus.Rpc.RespondAsync(responder);
        }
    }
}
