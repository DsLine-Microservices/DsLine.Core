using System.Collections.Generic;

namespace DsLine.Core.RabbitMQ.RabbitMQ.Types
{
    public interface IFilter<TResult, in TQuery> where TQuery : IQuery
    {
        IEnumerable<TResult> Filter(IEnumerable<TResult> values, TQuery query);
    }
}