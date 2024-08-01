namespace CarRental.Core.Models
{
    public class RentOrder
    {
        public Client Client { get; set; }
        public Car Car { get; set; }
        public int ClientId { get; set; }
        public int ElectricCarId { get; set; }
        public int OilFuelCarId { get; set; }
        public DateTime OrderStartDate { get; set; }
        public int OrderDays { get; set; }
        public RentOrder() { }
        public RentOrder(Client client, Car car, DateTime orderStartDate, int orderDays)
        {
            Client = client;
            Car = car;
            OrderStartDate = orderStartDate;
            OrderDays = orderDays;
        }
        public decimal CountRentPrice()
        {
            decimal total = 0;
            total = Car.RentPrice * OrderDays;
            return total;
        }
        public DateTime GetOrderEndDate()
        {
            return OrderStartDate.AddDays(OrderDays);
        }

        public override string ToString()
        {
            int rentedCarIdByType = 0;
            if (Car is ElectricCar)
            {
                rentedCarIdByType = Car.Id;
            }
            return $"{Client} ordered {Car} for {OrderDays} days";
        }
    }
}
