using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IRentOrderService
    {
        List<RentOrder> GetAllOrders();

    }
}
