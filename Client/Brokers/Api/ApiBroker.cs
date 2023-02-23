using System.Net.Http.Json;

namespace SCMDWH.Client.Brokers.Api
{
    public partial class ApiBroker : IApiBroker
    {
        private readonly HttpClient _httpClient;

        public ApiBroker(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<T> GetAsync<T>(string relativeUrl) =>
            await _httpClient.GetFromJsonAsync<T>(relativeUrl);

      
        private async Task<HttpResponseMessage> PostAsync<T>(string relativeUrl, T content) =>
            await _httpClient.PostAsJsonAsync<T>(relativeUrl, content);

        private async Task<HttpResponseMessage> PutAsync<T>(string relativeUrl, T content) =>
           await _httpClient.PutAsJsonAsync<T>(relativeUrl, content);

        private async Task<HttpResponseMessage> DeleteAsync(string relativeUrl) =>
            await _httpClient.DeleteAsync(relativeUrl);

    }
}
