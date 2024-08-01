using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface ICarsRepository
    {
        List<Car> ReadCars();
        void WriteCars(List<Car> carList);
        List<ElectricCar> GetAllElectricCars();
        List<OilFuelCar> GetAllOilFuelCars();
        void InsertElectricCar(ElectricCar ev);
        void InsertOilFuelCar(OilFuelCar v);
        Car GetElectricCarById(int id);
        Car GetOilFuelCarById(int id);

    }
}
