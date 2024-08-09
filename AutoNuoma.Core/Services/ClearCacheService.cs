using CarRental.Core.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarRental.Core.Services
{
    public class ClearCacheService : IClearCacheService
    {
        public readonly IMongoDbCacheRepository _mongoDbCacheRepository;
        public ClearCacheService(IMongoDbCacheRepository mongoDbCacheRepository)
        {
            _mongoDbCacheRepository = mongoDbCacheRepository;
        }

        public async Task ClearCache()
        {
            while (true)
            {
                Console.WriteLine("Cache clear in 1 minute");
                await Task.Delay(TimeSpan.FromMinutes(1));
                var clnClear = _mongoDbCacheRepository.ClearClientsCache();

                await Task.WhenAll(clnClear);
                Console.WriteLine("All cache has been cleared");
            }
        }
    }
}
