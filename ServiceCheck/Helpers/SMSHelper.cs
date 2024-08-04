using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceCheck.Helpers
{
    public class SMSHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public SMSHelper()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<TResponse> SendRequest<TRequest, TResponse>(
            HttpMethod method,
            string url)
        {
            try
            {
                await LogService.LogAsync($"[Telsam]: URL: {url}, Method: {method.Method}");

                var request = new HttpRequestMessage(method, url);
             
                // İsteği gönder ve yanıtı al
                var response = await _httpClient.SendAsync(request);
                string responseContent = await response.Content.ReadAsStringAsync();

                // Yanıt durumunu kontrol et ve logla
                if (!response.IsSuccessStatusCode)
                    await LogService.LogAsync($"[Telsam]: Request failed. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}, Content: {responseContent}");
                else
                    await LogService.LogAsync($"[Telsam]: Request made successfully. Content: {responseContent}");

                return JsonHelper.Deserialize<TResponse>(responseContent);
            }
            catch (Exception exception)
            {
                await LogService.LogAsync($"[Telsam]: Error occurred: {exception}");
                return JsonHelper.Deserialize<TResponse>(null);
            }
        }
    }
}
