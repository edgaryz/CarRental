using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IRentOrderRepository
    {
        List<RentOrder> GetAllOrdersFromDb();
        RentOrder GetOrderById(int id);
        void CreateElectricCarOrder(RentOrder newOrder);
        void CreateOilFuelCarOrder(RentOrder newOrder);
        List<RentOrder> GetOrderByClient(Client client);
    }
}
