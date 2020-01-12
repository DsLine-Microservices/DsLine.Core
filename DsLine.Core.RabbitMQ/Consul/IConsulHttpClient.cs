using System.Threading.Tasks;

namespace DsLine.Core.Consul
{
    public interface IConsulHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}

