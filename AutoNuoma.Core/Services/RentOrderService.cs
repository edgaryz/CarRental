using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Services
{
    public class RentOrderService : IRentOrderService
    {
        private readonly IRentOrderRepository _rentOrderRepository;
        private readonly ICarsRepository _carRepository;
        private readonly IClientRepository _clientRepository;
        public RentOrderService(IRentOrderRepository rentOrderRepository, ICarsRepository carsRepository, IClientRepository clientRepository)
        {
            _rentOrderRepository = rentOrderRepository;
            _carRepository = carsRepository;
            _clientRepository = clientRepository;
        }

        public List<RentOrder> GetAllOrders()
        {
            var orders = _rentOrderRepository.GetAllOrdersFromDb();
            foreach (var order in orders) {
                order.Client = _clientRepository.GetClientById(order.ClientId);
                if (order.ElectricCarId > 0)
                {
                    order.Car = _carRepository.GetElectricCarById(order.ElectricCarId);
                }
                 else
                {
                    order.Car = _carRepository.GetOilFuelCarById(order.OilFuelCarId);
                }
            }
            return orders;
        }

        public void CreateElectricCarOrder(RentOrder newOrder)
        {
            _rentOrderRepository.CreateElectricCarOrder(newOrder);
        }

        public void CreateOilFuelCarOrder(RentOrder newOrder)
        {
            _rentOrderRepository.CreateOilFuelCarOrder(newOrder);
        }

        public RentOrder GetOrderById(int id)
        {
            return _rentOrderRepository.GetOrderById(id);
        }
    }
}
