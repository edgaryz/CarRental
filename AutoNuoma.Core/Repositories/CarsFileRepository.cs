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
                    string[] values = line.Split(',');
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
                //reikia atskirti su if ar electric ar oil based
                //ir reikia foreach nes paduodu lista ir is listo pasiimti values
                sw.WriteLine($"{carList.Name},{employee.Age}");
            }
        }
    }
}
