using System.Collections.Generic;
using System.Threading.Tasks;
using DsLine.Core.Messages;

namespace DsLine.Core.RabbitMQ
{
    public interface IBusPublisher
    {
        Task SendAsync<TCommand>(TCommand command, ICorrelationContext context, string tenant)
            where TCommand : ICommand;

        Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context, string tenant)
            where TEvent : IEvent;
    }
}