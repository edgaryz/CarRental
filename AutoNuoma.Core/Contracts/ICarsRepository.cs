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
        ElectricCar GetElectricCarById(int id);
        OilFuelCar GetOilFuelCarById(int id);

    }
}
