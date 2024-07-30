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

        public override string ToString()
        {
            return $"{Id} {Brand} {Model}, rent price: {RentPrice} Eur, fuel consumption: {FuelConsumption}.";
        }
    }
}
