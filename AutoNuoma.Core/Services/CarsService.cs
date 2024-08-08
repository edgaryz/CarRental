using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Services
{
    public class CarsService : ICarsService
    {
        private readonly ICarsRepository _carsRepository;
        public CarsService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        //Electric Cars
        public async Task<List<ElectricCar>> GetAllElectricCars()
        {
            return await _carsRepository.GetAllElectricCars();
        }

        public async Task<ElectricCar> GetElectricCarById(int id)
        {
            return await _carsRepository.GetElectricCarById(id);
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
            return await _carsRepository.GetAllOilFuelCars();
        }

        public async Task<OilFuelCar> GetOilFuelCarById(int id)
        {
            return await _carsRepository.GetOilFuelCarById(id);
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
