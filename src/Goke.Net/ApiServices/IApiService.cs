using System.Net.Http;
using System.Threading.Tasks;

namespace Goke.Net.Services
{
    public interface IApiService
    {
        Task<HttpResponseMessage> AddAsync<T>(string requestUri, T value);
        Task<HttpResponseMessage> DeleteAsync<T>(string requestUri);
        Task<T> GetAsync<T>(string requestUri);
        Task<HttpResponseMessage> UpdateAsync<T>(string requestUri, T value);
    }
}