using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IRentOrderRepository
    {
        List<RentOrder> GetAllOrdersFromDb();
        void CreateOrder(RentOrder newOrder, Car car, Client client);
        List<RentOrder> GetOrderByClient(Client client);
    }
}
