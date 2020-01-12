using System.Threading.Tasks;

namespace DsLine.Core.Fabio
{
    public interface IFabioHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}