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
        public int EmployeeId { get; set; }
        public RentOrder() { }
        public RentOrder(Client client, Car car, DateTime orderStartDate, int orderDays)
        {
            Client = client;
            Car = car;
            OrderStartDate = orderStartDate;
            OrderDays = orderDays;
        }
        public RentOrder(int clientId, int electricCarId, DateTime orderStartDate, int orderDays, int employeeId)
        {
            ClientId = clientId;
            ElectricCarId = electricCarId;
            OrderStartDate = orderStartDate;
            OrderDays = orderDays;
            EmployeeId = employeeId;
        }
        public RentOrder(int clientId, DateTime orderStartDate, int orderDays, int employeeId, int oilFuelCarId)
        {
            ClientId = clientId;
            OilFuelCarId = oilFuelCarId;
            OrderStartDate = orderStartDate;
            OrderDays = orderDays;
            EmployeeId = employeeId;
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
            return $"{Client} ordered {Car} for {OrderDays} days. Order was managed by employee by ID: {EmployeeId}.";
        }
    }
}
