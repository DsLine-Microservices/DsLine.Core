using System;
using DsLine.Core.Messages;
using DsLine.Core.RabbitMQ.Types;

namespace DsLine.Core.RabbitMQ
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, DShopException, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, DShopException, IRejectedEvent> onError = null) 
            where TEvent : IEvent;
    }
}
