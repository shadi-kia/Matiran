using System.Text.Json;
using MCrypto.Core.Interfaces;
using MCrypto.Core.Models;
using MCrypto.Infrastructure.Redis;


namespace MCrypto.Applicaton.Services
  
{
    public class CryptoCurrencyService:ICryptoCurrencyRepository
    {
        private readonly ICryptoCurrencyRepository _repository;
        private readonly RedisCache _cache;
        public CryptoCurrencyService(ICryptoCurrencyRepository repository,RedisCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public Task<IEnumerable<CryptoCurrency>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CryptoCurrency> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CryptoCurrency>> GetCryptoCurrenciesAsync()
        {
            //return await _repository.GetAllAsync();

            const string cacheKey = "cryptocurrencies";
            var cachedData = await _cache.GetASync(cacheKey);

            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<IEnumerable<CryptoCurrency>>(cachedData)!;
            }

            var data = await _repository.GetAllAsync();
            await _cache.SetAsync(cacheKey, JsonSerializer.Serialize(data), TimeSpan.FromMinutes(10));
            return data;

        }
    }
}
