using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface ICarRentService
    {
        void CreateOrder(RentOrder order);
        void CountTotalRentPrice();
        List<RentOrder> GetOrderByClient(Client client);
        List<RentOrder> GetAllOrders();
        List<Car> GetAllCars();
        void AddNewCar(Car car);
    }
}
