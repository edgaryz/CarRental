using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface ICarsService
    {
        List<Car> FindCarByBrand(string brand);
        List<Car> GetAllCars();
        List<ElectricCar> GetAllElectricCars();
        List<OilFuelCar> GetAllOilFuelCars();
        void InsertNewCar(Car car);
    }
}
