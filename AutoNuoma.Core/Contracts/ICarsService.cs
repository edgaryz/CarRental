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
        ElectricCar GetElectricCarById(int id);
        OilFuelCar GetOilFuelCarById(int id);
        void UpdateElectricCarInfo(ElectricCar car);
        void UpdateOilFuelCarInfo(OilFuelCar car);
    }
}
