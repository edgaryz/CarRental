using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface ICarRentService
    {
        void CreateOrder(string clientName, string clientLastName, int autoId, DateTime orderStartDate, int orderDays);
        void CountTotalRentPrice();
        List<RentOrder> GetOrderByClient(Client client);
        List<RentOrder> GetAllOrders();
        List<Car> GetAllCars();
        void AddNewCar(Car car);
        List<Client> GetAllClients();
    }
}
