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

        public List<Car> FindCarByBrand(string brand)
        {
            List<Car> searchResult = new List<Car>();
            List<Car> cars = _carsRepository.ReadCars();
            foreach (Car a in cars)
            {
                if (a.Brand == brand)
                    searchResult.Add(a);
            }
            return searchResult;
        }

        public List<Car> GetAllCars()
        {
            return _carsRepository.ReadCars();
        }

        public List<ElectricCar> GetAllElectricCars()
        {
            return _carsRepository.GetAllElectricCars();
        }

        public List<OilFuelCar> GetAllOilFuelCars()
        {
            return _carsRepository.GetAllOilFuelCars();
        }

        public ElectricCar GetElectricCarById(int id)
        {
            return _carsRepository.GetElectricCarById(id);
        }

        public OilFuelCar GetOilFuelCarById(int id)
        {
            return _carsRepository.GetOilFuelCarById(id);
        }

        public void InsertNewCar(Car car)
        {
            if (car is ElectricCar)
                _carsRepository.InsertElectricCar((ElectricCar)car);
            else
                _carsRepository.InsertOilFuelCar((OilFuelCar)car);
        }

    }
}
