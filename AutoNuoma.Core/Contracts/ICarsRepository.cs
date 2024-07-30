using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface ICarsRepository
    {
        List<Car> ReadCars();
        void WriteCars(List<Car> carList);
    }
}
