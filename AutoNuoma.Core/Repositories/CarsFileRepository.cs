﻿using CarRental.Core.Contracts;
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

        public List<ElectricCar> GetAllElectricCars()
        {
            throw new NotImplementedException();
        }

        public List<OilFuelCar> GetAllOilFuelCars()
        {
            throw new NotImplementedException();
        }

        public Car GetElectricCarById(int id)
        {
            throw new NotImplementedException();
        }

        public Car GetOilFuelCarById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertElectricCar(ElectricCar ev)
        {
            throw new NotImplementedException();
        }

        public void InsertOilFuelCar(OilFuelCar v)
        {
            throw new NotImplementedException();
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

        ElectricCar ICarsRepository.GetElectricCarById(int id)
        {
            throw new NotImplementedException();
        }

        OilFuelCar ICarsRepository.GetOilFuelCarById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
