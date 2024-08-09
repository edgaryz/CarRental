using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Repositories
{
    public class CarsFileRepository : ICarsRepository
    {
        private readonly string _filePath;
        public CarsFileRepository(string autoFilePath)
        {
            _filePath = autoFilePath;
        }

        public List<Car> ReadCars()
        {
            List<Car> cars = new List<Car>();
            using (StreamReader sr = new StreamReader(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length == 5)
                    {
                        //oil fuel based car
                        cars.Add(new OilFuelCar(
                            int.Parse(values[0]),
                            values[1],
                            values[2],
                            decimal.Parse(values[3]),
                            values[4]));
                    }
                    else
                    {
                        //electric car
                        cars.Add(new ElectricCar(
                            int.Parse(values[0]),
                            values[1],
                            values[2],
                            decimal.Parse(values[3]),
                            values[4],
                            int.Parse(values[5])));
                    }

                }
            }
            return cars;
        }

        public void WriteCars(List<Car> carList)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                //based on Car type
                if (carList is ElectricCar)
                {
                    foreach (ElectricCar car in carList)
                    {
                        //ElectricCar line
                        sw.WriteLine($"" +
                            $"{car.Id}," +
                            $"{car.Brand}," +
                            $"{car.Model}," +
                            $"{car.RentPrice}," +
                            $"{car.BatteryCapacity}," +
                            $"{car.BatteryChargingTime}");
                    }
                }
                else
                {
                    foreach (OilFuelCar car in carList)
                    {
                        //OilFuelCar line
                        sw.WriteLine($"" +
                            $"{car.Id}," +
                            $"{car.Brand}," +
                            $"{car.Model}," +
                            $"{car.RentPrice}," +
                            $"{car.FuelConsumption}");
                    }
                }
            }
        }

        public Task UpdateElectricCar(ElectricCar car)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOilFuelCar(OilFuelCar car)
        {
            throw new NotImplementedException();
        }

        public Task DeleteElectricCar(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOilFuelCar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectricCar>> GetAllElectricCars()
        {
            throw new NotImplementedException();
        }

        public Task<List<OilFuelCar>> GetAllOilFuelCars()
        {
            throw new NotImplementedException();
        }

        public Task<ElectricCar> GetElectricCarById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OilFuelCar> GetOilFuelCarById(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertElectricCar(ElectricCar ev)
        {
            throw new NotImplementedException();
        }

        public Task InsertOilFuelCar(OilFuelCar v)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetElectricCarCountFromDb()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetOilFuelCarCountFromDb()
        {
            throw new NotImplementedException();
        }
    }
}
