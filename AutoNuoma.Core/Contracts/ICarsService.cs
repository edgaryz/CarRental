using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface ICarsService
    {
        void ReadFile();
        void WriteFile();
        void AddCar(Car car);
        List<Car> FindCarByBrand(string brand);
        List<Car> GetAllCars();
    }
}
