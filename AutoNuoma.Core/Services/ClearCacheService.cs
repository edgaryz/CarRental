using CarRental.Core.Contracts;

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
                var evClear = _mongoDbCacheRepository.ClearElectricCarCache();
                var ofcClear = _mongoDbCacheRepository.ClearOilFuelCarsCache();
                var clnClear = _mongoDbCacheRepository.ClearClientsCache();
                var empClear = _mongoDbCacheRepository.ClearEmployeeCache();

                await Task.WhenAll(evClear, ofcClear, clnClear, empClear);
                Console.WriteLine("All cache has been cleared");
            }
        }

        public async Task EnsureConsistency()
        {
            while (true)
            {
                //gauni count is mongo + count is DB, jeigu skiriasi, delete cache
                await Task.Delay(TimeSpan.FromMinutes(1));
                Console.WriteLine("Ensured consistency cache clear");
            }
        }
    }
}
