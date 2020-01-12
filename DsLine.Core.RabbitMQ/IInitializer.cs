using System.Threading.Tasks;

namespace DsLine.Core
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}