using RawRabbit.Configuration;
using System.Collections.Generic;

namespace DsLine.Core.RabbitMQ
{
    public class RabbitMqOptions : RawRabbitConfiguration
    {
        public string Namespace { get; set; }
        public int Retries { get; set; }
        public int RetryInterval { get; set; }
    }

    //public class ListRabbitMaOptions
    //{
    //    public List<RabbitMqOptions> ListRabbitMq { get; set; }

    //}
}