namespace CarRental.Core.Models
{
    public class OilFuelCar : Car
    {
        public string FuelConsumption { get; set; }
        public OilFuelCar() { }
        public OilFuelCar(int id, string brand, string model, decimal rentPrice, string fuelConsumption) : base(id, brand, model, rentPrice)
        {
            FuelConsumption = fuelConsumption;
        }
        public OilFuelCar(string brand, string model, decimal rentPrice, string fuelConsumption) : base(brand, model, rentPrice)
        {
            FuelConsumption = fuelConsumption;
        }

        public override string ToString()
        {
            return $"Id - {Id}, {Brand} {Model}, rent price: {RentPrice.ToString("F2")} Eur, fuel consumption: {FuelConsumption}.";
        }
    }
}
