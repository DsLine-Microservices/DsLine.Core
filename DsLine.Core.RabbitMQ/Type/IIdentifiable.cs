using System;

namespace DsLine.Core.RabbitMQ.RabbitMQ.Types
{
    public interface IIdentifiable
    {
         Guid Id { get; }
    }
}