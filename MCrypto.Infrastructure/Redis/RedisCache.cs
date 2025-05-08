using StackExchange.Redis;

namespace MCrypto.Infrastructure.Redis
{
    public class RedisCache
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public RedisCache(string cn)
        {
            _redis = ConnectionMultiplexer.Connect(cn);
            _db = _redis.GetDatabase();
        }
        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            await _db.StringSetAsync(key, value, expiry);
        }
        public async Task<string?> GetASync(string key)
        {
            var value = await _db.StringGetAsync(key);
            return value.HasValue ? value.ToString() : null;
        }
    }
}
