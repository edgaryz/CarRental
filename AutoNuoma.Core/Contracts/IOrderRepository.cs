using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IOrderRepository
    {
        List<RentOrder> GetAllOrdersFromDb();
        void CreateOrder(RentOrder newOrder);
        List<RentOrder> GetOrderByClient(Client client);
    }
}
