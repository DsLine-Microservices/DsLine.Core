using DsLine.Core.RabbitMQ;
using DsLine.Core.Messages;
using System.Threading.Tasks;

namespace DsLine.Core.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}