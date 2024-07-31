namespace CarRental.Core.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal RentPrice { get; set; }

        public Car() { }

        public Car(int id, string brand, string model, decimal rentPrice)
        {
            Id = id;
            Brand = brand;
            Model = model;
            RentPrice = rentPrice;
        }
        public Car(string brand, string model, decimal rentPrice)
        {
            Brand = brand;
            Model = model;
            RentPrice = rentPrice;
        }

        public string getInfo()
        {
            return $"ID: {Id}, {Brand} {Model}, rent price {RentPrice}";
        }
    }
}
