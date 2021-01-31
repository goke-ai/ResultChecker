using Goke.Net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Goke.Net.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            var resp = await _httpClient.GetFromJsonAsync<T>(requestUri);
            return resp;
        }

        public async Task<HttpResponseMessage> AddAsync<T>(string requestUri, T value)
        {
            var result = await _httpClient.PostAsJsonAsync(requestUri, value);
            await EnsureSuccessStatusCode(result);
            return result;
        }

        public async Task<HttpResponseMessage> UpdateAsync<T>(string requestUri, T value)
        {
            var result = await _httpClient.PutAsJsonAsync(requestUri, value);
            await EnsureSuccessStatusCode(result);
            return result;
        }

        public async Task<HttpResponseMessage> DeleteAsync<T>(string requestUri)
        {
            var result = await _httpClient.DeleteAsync(requestUri);
            await EnsureSuccessStatusCode(result);
            return result;
        }

        private static async Task EnsureSuccessStatusCode(HttpResponseMessage result)
        {
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest || result.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }
            result.EnsureSuccessStatusCode();
        }



    }
}
