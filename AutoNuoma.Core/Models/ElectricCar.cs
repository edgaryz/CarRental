namespace CarRental.Core.Models
{
    public class ElectricCar : Car
    {
        public string BatteryCapacity { get; set; }
        public int BatteryChargingTime { get; set; }

        public ElectricCar() { }
        public ElectricCar(int id, string brand, string model, decimal rentPrice, string batteryCapacity, int batteryChargingTime) : base(id, brand, model, rentPrice)
        {
            BatteryCapacity = batteryCapacity;
            BatteryChargingTime = batteryChargingTime;
        }
        public ElectricCar(string brand, string model, decimal rentPrice, string batteryCapacity, int batteryChargingTime) : base(brand, model, rentPrice)
        {
            BatteryCapacity = batteryCapacity;
            BatteryChargingTime = batteryChargingTime;
        }

        public override string ToString()
        {
            return $"{Id} {Brand} {Model} rent price: {RentPrice.ToString("F2")} Eur, battery: {BatteryCapacity}, battery charge time: {BatteryChargingTime} val.";
        }
    }
}
