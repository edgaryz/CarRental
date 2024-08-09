using CarRental.Core.Contracts;
using CarRental.Core.Models;
using MongoDB.Driver;

namespace CarRental.Core.Repositories
{
    public class MongoDbCacheRepository : IMongoDbCacheRepository
    {
        private IMongoCollection<Employee> _employeesCache;
        private IMongoCollection<Client> _clientsCache;
        private IMongoCollection<ElectricCar> _evCarsCache;
        private IMongoCollection<OilFuelCar> _ofcCarsCache;
        public MongoDbCacheRepository(IMongoClient mongoClient) {
            _employeesCache = mongoClient.GetDatabase("employees").GetCollection<Employee>("employees_cache");
            _clientsCache = mongoClient.GetDatabase("clients").GetCollection<Client>("clients_cache");
            _evCarsCache = mongoClient.GetDatabase("electric cars").GetCollection<ElectricCar>("electric_cars_cache");
            _ofcCarsCache = mongoClient.GetDatabase("oil fuel cars").GetCollection<OilFuelCar>("oil_fuel_cars_cache");
        }

        //Electric Cars
        public async Task AddElectricCar(ElectricCar ev)
        {
            await _evCarsCache.InsertOneAsync(ev);
        }

        public async Task<ElectricCar> GetElectricCarById(int id)
        {
            try
            {
                return (await _evCarsCache.FindAsync<ElectricCar>(x => x.Id == id)).First();
            }
            catch
            {
                return null;
            }
        }

        //Oil Fuel Cars
        public async Task AddOilFuelCar(OilFuelCar ofc)
        {
            await _ofcCarsCache.InsertOneAsync(ofc);
        }

        public async Task<OilFuelCar> GetOilFuelCarById(int id)
        {
            try
            {
                return (await _ofcCarsCache.FindAsync<OilFuelCar>(x => x.Id == id)).First();
            }
            catch
            {
                return null;
            }
        }

        public async Task ClearOilFuelCarsCache(OilFuelCar ofc)
        {
            await _ofcCarsCache.InsertOneAsync(ofc);
        }

        //Client
        public async Task AddClient(Client client)
        {
            await _clientsCache.InsertOneAsync(client);
        }

        public async Task<Client> GetClientById(int id)
        {
            try
            {
                return (await _clientsCache.FindAsync<Client>(x => x.Id == id)).First();
            }
            catch
            {
                return null;
            }
        }

        public async Task ClearClientsCache()
        {
            await _clientsCache.Database.DropCollectionAsync("clients_cache");
        }

        //Employee
        public async Task AddEmployee(Employee employee)
        {
            await _employeesCache.InsertOneAsync(employee);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                return (await _employeesCache.FindAsync<Employee>(x => x.Id == id)).First();
            }
            catch
            {
                return null;
            }
        }

    }
}
