using CarRental.Core.Contracts;
using CarRental.Core.Models;
using MongoDB.Driver;

namespace CarRental.Core.Repositories
{
    public class MongoDbCacheRepository : IMongoDbCacheRepository
    {
        private IMongoCollection<ElectricCar> _evCarsCache;
        private IMongoCollection<OilFuelCar> _ofcCarsCache;
        private IMongoCollection<Client> _clientsCache;
        private IMongoCollection<Employee> _employeesCache;

        public MongoDbCacheRepository(IMongoClient mongoClient)
        {
            _evCarsCache = mongoClient.GetDatabase("electric_cars").GetCollection<ElectricCar>("electric_cars_cache");
            _ofcCarsCache = mongoClient.GetDatabase("oil_fuel_cars").GetCollection<OilFuelCar>("oil_fuel_cars_cache");
            _clientsCache = mongoClient.GetDatabase("clients").GetCollection<Client>("clients_cache");
            _employeesCache = mongoClient.GetDatabase("employees").GetCollection<Employee>("employees_cache");

        }

        //Electric Cars
        public async Task<List<ElectricCar>> GetElectricCarList()
        {
            return await _evCarsCache.Find<ElectricCar>(x => true).ToListAsync();
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

        public async Task InsertElectricCarList(List<ElectricCar> evList)
        {
            await _evCarsCache.InsertManyAsync(evList);
        }

        public async Task InsertElectricCar(ElectricCar ev)
        {
            await _evCarsCache.InsertOneAsync(ev);
        }

        public async Task ClearElectricCarCache()
        {
            await _evCarsCache.Database.DropCollectionAsync("electric_cars_cache");
        }

        public async Task<int> GetElectricCarCount()
        {
            return await _evCarsCache.CountDocumentsAsync<int>(x => true);
        }

        //Oil Fuel Cars
        public async Task<List<OilFuelCar>> GetOilFuelCarList()
        {
            return await _ofcCarsCache.Find<OilFuelCar>(x => true).ToListAsync();
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

        public async Task InsertOilFuelCarList(List<OilFuelCar> ofcList)
        {
            await _ofcCarsCache.InsertManyAsync(ofcList);
        }

        public async Task InsertOilFuelCar(OilFuelCar ofc)
        {
            await _ofcCarsCache.InsertOneAsync(ofc);
        }

        public async Task ClearOilFuelCarsCache()
        {
            await _ofcCarsCache.Database.DropCollectionAsync("oil_fuel_cars_cache");
        }

        //Clients
        public async Task<List<Client>> GetClientList()
        {
            return await _clientsCache.Find<Client>(x => true).ToListAsync();
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

        public async Task InsertClientList(List<Client> clnList)
        {
            await _clientsCache.InsertManyAsync(clnList);
        }

        public async Task InsertClient(Client client)
        {
            await _clientsCache.InsertOneAsync(client);
        }

        public async Task ClearClientsCache()
        {
            await _clientsCache.Database.DropCollectionAsync("clients_cache");
        }

        //Employees
        public async Task<List<Employee>> GetEmployeeList()
        {
            return await _employeesCache.Find<Employee>(x => true).ToListAsync();
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

        public async Task InsertEmployeeList(List<Employee> empList)
        {
            await _employeesCache.InsertManyAsync(empList);
        }

        public async Task InsertEmployee(Employee employee)
        {
            await _employeesCache.InsertOneAsync(employee);
        }

        public async Task ClearEmployeeCache()
        {
            await _employeesCache.Database.DropCollectionAsync("employees_cache");
        }

    }
}
