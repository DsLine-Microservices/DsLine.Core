using System.Threading.Tasks;
using Consul;

namespace DsLine.Core.Consul
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string name);
    }
}