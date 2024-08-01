using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IRentOrderRepository
    {
        List<RentOrder> GetAllOrdersFromDb();
        void CreateElectricCarOrder(RentOrder newOrder);
        void CreateOilFuelCarOrder(RentOrder newOrder);
        List<RentOrder> GetOrderByClient(Client client);
    }
}
