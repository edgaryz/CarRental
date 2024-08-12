using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Core.Repositories
{
    public class CarsEFDbRepository : ICarsRepository
    {
        //Electric Cars
        public async Task<List<ElectricCar>> GetAllElectricCars()
        {
            using (var context = new MyDbContext())
            {
                List<ElectricCar> allElectricCars = await context.ElectricCars.ToListAsync();
                return allElectricCars;
            }
        }

        public async Task<ElectricCar> GetElectricCarById(int id)
        {
            using (var context = new MyDbContext())
            {
                return await context.ElectricCars.FindAsync(id);
            }
        }

        public async Task InsertElectricCar(ElectricCar ev)
        {
            using (var context = new MyDbContext())
            {
                await context.ElectricCars.AddAsync(ev);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateElectricCar(ElectricCar car)
        {
            using (var context = new MyDbContext())
            {
                await context.ElectricCars
                    .Where(x => x.Id == car.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.Brand, car.Brand)
                        .SetProperty(y => y.Model, car.Model)
                        .SetProperty(y => y.RentPrice, car.RentPrice)
                        .SetProperty(y => y.BatteryCapacity, car.BatteryCapacity)
                        .SetProperty(y => y.BatteryChargingTime, car.BatteryChargingTime));
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteElectricCar(int id)
        {
            using (var context = new MyDbContext())
            {
                context.ElectricCars.Remove(await context.ElectricCars.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> GetElectricCarCountFromDb()
        {
            using (var context = new MyDbContext())
            {
                var allElectricCarsCount = await context.ElectricCars.CountAsync();
                return allElectricCarsCount;
            }
        }

        //Oil Fuel Cars
        public async Task<List<OilFuelCar>> GetAllOilFuelCars()
        {
            using (var context = new MyDbContext())
            {
                List<OilFuelCar> allOilFuelCars = await context.OilFuelCars.ToListAsync();
                return allOilFuelCars;
            }
        }

        public async Task<OilFuelCar> GetOilFuelCarById(int id)
        {
            using (var context = new MyDbContext())
            {
                return await context.OilFuelCars.FindAsync(id);
            }
        }

        public async Task InsertOilFuelCar(OilFuelCar v)
        {
            using (var context = new MyDbContext())
            {
                await context.OilFuelCars.AddAsync(v);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateOilFuelCar(OilFuelCar car)
        {
            using (var context = new MyDbContext())
            {
                await context.OilFuelCars
                    .Where(x => x.Id == car.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.Brand, car.Brand)
                        .SetProperty(y => y.Model, car.Model)
                        .SetProperty(y => y.RentPrice, car.RentPrice)
                        .SetProperty(y => y.FuelConsumption, car.FuelConsumption));
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteOilFuelCar(int id)
        {
            using (var context = new MyDbContext())
            {
                context.OilFuelCars.Remove(await context.OilFuelCars.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> GetOilFuelCarCountFromDb()
        {
            using (var context = new MyDbContext())
            {
                var allOilFuelCarsCount = await context.OilFuelCars.CountAsync();
                return allOilFuelCarsCount;
            }
        }

        //File System
        public List<Car> ReadCars()
        {
            throw new NotImplementedException();
        }

        public void WriteCars(List<Car> carList)
        {
            throw new NotImplementedException();
        }
    }
}
