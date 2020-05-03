using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DsLine.Core.Messages;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Enrichers.MessageContext;
using RawRabbit.Pipe;

namespace DsLine.Core.RabbitMQ
{
    public class BusPublisher : IBusPublisher
    {
        private readonly List<IBusClient> _busClient;

        public BusPublisher(List<IBusClient> busClient)
        {
            _busClient = busClient;
        }

        public async Task SendAsync<TCommand>(TCommand command, ICorrelationContext context, string tenant = null)
            where TCommand : ICommand

        {
            // Parallel.ForEach(_busClient, busclient => busclient.PublishAsync(command, ctx => ctx.UseMessageContext(context)));

            _busClient.ForEach(async x => { await x.PublishAsync(command, ctx => ctx.UseMessageContext(context)); });
            IBusClient client = _busClient.Where(x =>
             {



                 //PropertyInfo propertyInfo = typeof(BusClient).GetProperty("_contextFactory", BindingFlags.NonPublic | BindingFlags.Instance);

                 //MethodInfo getter = propertyInfo.GetGetMethod(nonPublic: true);

                 RawRabbit.Pipe.PipeContextFactory PipeContextFactory = typeof(RawRabbit.BusClient).GetField("_contextFactory", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(x) as PipeContextFactory;




                 //PropertyInfo propertyInfoPipeContextFactory = typeof(PipeContextFactory).GetProperty("_config", BindingFlags.NonPublic | BindingFlags.Instance);

                 //MethodInfo getterPipeContextFactory = propertyInfoPipeContextFactory.GetGetMethod(nonPublic: true);

                 //RawRabbitConfiguration RawRabbitConfiguration = (RawRabbitConfiguration)getterPipeContextFactory.Invoke(PipeContextFactory, null);

                 RawRabbit.Configuration.RawRabbitConfiguration RawRabbitConfiguration = typeof(RawRabbit.Pipe.PipeContextFactory).GetField("_config", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(x) as RawRabbit.Configuration.RawRabbitConfiguration;

                 if (RawRabbitConfiguration.VirtualHost == tenant)
                 {
                     return true;
                 }

                 return false;
             }).SingleOrDefault();


            await client.PublishAsync(command, ctx => ctx.UseMessageContext(context));
        }






        public async Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context, string tenant = null)
            where TEvent : IEvent
        {
            //  Parallel.ForEach(_busClient, busclient => busclient.PublishAsync(@event, ctx => ctx.UseMessageContext(context)));

            IBusClient client = _busClient.Where(x =>
            {



                //PropertyInfo propertyInfo = typeof(BusClient).GetProperty("_contextFactory", BindingFlags.NonPublic | BindingFlags.Instance);

                //MethodInfo getter = propertyInfo.GetGetMethod(nonPublic: true);

                RawRabbit.Pipe.PipeContextFactory pipeContextFactory = typeof(RawRabbit.BusClient).GetField("_contextFactory", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(x) as PipeContextFactory;




                //PropertyInfo propertyInfoPipeContextFactory = typeof(PipeContextFactory).GetProperty("_config", BindingFlags.NonPublic | BindingFlags.Instance);

                //MethodInfo getterPipeContextFactory = propertyInfoPipeContextFactory.GetGetMethod(nonPublic: true);

                //RawRabbitConfiguration RawRabbitConfiguration = (RawRabbitConfiguration)getterPipeContextFactory.Invoke(PipeContextFactory, null);

                RawRabbit.Configuration.RawRabbitConfiguration RawRabbitConfiguration = typeof(RawRabbit.Pipe.PipeContextFactory).GetField("_config", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(pipeContextFactory) as RawRabbit.Configuration.RawRabbitConfiguration;

                if (RawRabbitConfiguration.VirtualHost == tenant)
                {
                    return true;
                }

                return false;
            }).SingleOrDefault();


            await client.PublishAsync(@event, ctx => ctx.UseMessageContext(context));

        }



    }

}