using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace SCMDWH.Client.JGHttpClient
{
    public class JGHttpClient
    {


        private HttpClient _httpClient;

        public JGHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> Get<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                var responseEx = await response.Content.ReadAsStringAsync();

                string respToWeb = response.StatusCode + "  " + responseEx;
                throw new Exception( respToWeb);
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }


        public async Task<T> Post<T>(string url, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(url,data);
            if (!response.IsSuccessStatusCode)
            {
                var responseEx = await response.Content.ReadAsStringAsync();

                string respToWeb = response.StatusCode + "  " + responseEx;
                throw new Exception(respToWeb);
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }


        public async Task<T> Put<T>(string url, T data)
        {
            var response = await _httpClient.PutAsJsonAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                var responseEx = await response.Content.ReadAsStringAsync();

                string respToWeb = response.StatusCode + "  " + responseEx;
                throw new Exception(respToWeb);
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);

        }

        public async Task<T> Delete<T>(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            if (!response.IsSuccessStatusCode) 
            {
                var responseEx = await response.Content.ReadAsStringAsync();

                string respToWeb = response.StatusCode + "  " + responseEx;
                throw new Exception(respToWeb);
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }




    }
}
