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

        public void AddCar(Car car)
        {
            throw new NotImplementedException();
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

        public void ReadFile()
        {
            throw new NotImplementedException();
        }

        public void WriteFile()
        {
            throw new NotImplementedException();
        }
    }
}
