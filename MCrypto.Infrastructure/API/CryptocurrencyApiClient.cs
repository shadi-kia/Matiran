using System.Net.Http;

namespace MCrypto.Infrastructure.API
{
    public class CryptocurrencyApiClient
    {
        private readonly HttpClient _httpClient;
        public CryptocurrencyApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<decimal> GetPriceAsync(string symbol)
        {
            var response = await _httpClient.GetAsync($"https://api.example.com/price/{symbol}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            return decimal.Parse(data);
        }
    }
}
