using System.Collections.Generic;

namespace DsLine.Core.RabbitMQ.RabbitMQ.Types
{
    public interface IPagedFilter<TResult, in TQuery> where TQuery : IQuery
    {
        PagedResult<TResult> Filter(IEnumerable<TResult> values, TQuery query);
    }
}