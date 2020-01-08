using DsLine.Core.RabbitMQ.RabbitMQ.Types;
using System.Threading.Tasks;

namespace DsLine.Core.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}