using DsLine.Core.RabbitMQ;
using DsLine.Core.Messages;
using System.Threading.Tasks;

namespace DsLine.Core.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}