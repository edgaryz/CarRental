using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Services
{
    public class CarsService : ICarsService
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IMongoDbCacheRepository _cache;
        public CarsService(ICarsRepository carsRepository, IMongoDbCacheRepository cache)
        {
            _carsRepository = carsRepository;
            _cache = cache;
        }

        //Electric Cars
        public async Task<List<ElectricCar>> GetAllElectricCars()
        {
            var evList = await _cache.GetElectricCarList();

            if (evList != null)
            {
                return evList;
            }

            evList = await _carsRepository.GetAllElectricCars();
            await _cache.InsertElectricCarList(evList);
            return evList;
        }

        public async Task<ElectricCar> GetElectricCarById(int id)
        {
            var ev = await _cache.GetElectricCarById(id);

            if (ev != null)
            {
                return ev;
            }

            ev = await _carsRepository.GetElectricCarById(id);
            await _cache.InsertElectricCar(ev);
            return ev;
        }

        public async Task InsertElectricCar(ElectricCar car)
        {
            await _carsRepository.InsertElectricCar(car);
        }

        public async Task UpdateElectricCar(ElectricCar car)
        {
            await _carsRepository.UpdateElectricCar(car);
        }
        public async Task DeleteElectricCar(int id)
        {
            await _carsRepository.DeleteElectricCar(id);
        }

        //Oil Fuel Cars
        public async Task<List<OilFuelCar>> GetAllOilFuelCars()
        {
            var ofcList = await _cache.GetOilFuelCarList();

            if (ofcList != null)
            {
                return ofcList;
            }

            ofcList = await _carsRepository.GetAllOilFuelCars();
            await _cache.InsertOilFuelCarList(ofcList);
            return ofcList;
        }

        public async Task<OilFuelCar> GetOilFuelCarById(int id)
        {
            var ofc = await _cache.GetOilFuelCarById(id);

            if (ofc != null)
            {
                return ofc;
            }

            ofc = await _carsRepository.GetOilFuelCarById(id);
            await _cache.InsertOilFuelCar(ofc);
            return ofc;
        }

        public async Task InsertOilFuelCar(OilFuelCar car)
        {
            await _carsRepository.InsertOilFuelCar(car);
        }

        public async Task UpdateOilFuelCar(OilFuelCar car)
        {
            await _carsRepository.UpdateOilFuelCar(car);
        }

        public async Task DeleteOilFuelCar(int id)
        {
            await _carsRepository.DeleteOilFuelCar(id);
        }

        //File System
        public List<Car> GetAllCars()
        {
            return _carsRepository.ReadCars();
        }

        public void InsertNewCar(Car car)
        {
            if (car is ElectricCar)
                _carsRepository.InsertElectricCar((ElectricCar)car);
            else
                _carsRepository.InsertOilFuelCar((OilFuelCar)car);
        }

        public List<Car> ReadCars()
        {
            throw new NotImplementedException();
        }

        public void WriteCars(List<Car> carList)
        {
            throw new NotImplementedException();
        }
    }
}
