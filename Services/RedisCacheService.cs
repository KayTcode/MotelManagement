using Microsoft.Extensions.Configuration;
using Services.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _db;
        public RedisCacheService(IConfiguration config)
        {
            var redis = ConnectionMultiplexer.Connect(config["Redis"]);
            _db = redis.GetDatabase();
        }
        public async Task<string> GetTokenAsync(int userId)

            => await _db.StringGetAsync($"RT: {userId}");


        public async Task RemoveTokenAsync(int userId)

           => await _db.KeyDeleteAsync($"RT: {userId}");


        public Task SetTokenAysnc(int userId, string refeshToken, TimeSpan expiry)

            => _db.StringSetAsync($"RT: {userId}", refeshToken, expiry);
    }
}
