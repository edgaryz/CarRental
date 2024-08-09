using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface ICarsRepository
    {
        //Electric Cars
        Task<List<ElectricCar>> GetAllElectricCars();
        Task<ElectricCar> GetElectricCarById(int id);
        Task InsertElectricCar(ElectricCar ev);
        Task UpdateElectricCar(ElectricCar car);
        Task DeleteElectricCar(int id);
        Task<int> GetElectricCarCountFromDb();

        //Oil Fuel Cars
        Task<List<OilFuelCar>> GetAllOilFuelCars();
        Task InsertOilFuelCar(OilFuelCar v);
        Task<OilFuelCar> GetOilFuelCarById(int id);
        Task UpdateOilFuelCar(OilFuelCar car);
        Task DeleteOilFuelCar(int id);
        Task<int> GetOilFuelCarCountFromDb();

        //File System
        List<Car> ReadCars();
        void WriteCars(List<Car> carList);
    }
}
