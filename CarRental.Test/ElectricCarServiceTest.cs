using CarRental.Core.Contracts;
using CarRental.Core.Models;
using CarRental.Core.Services;
using Moq;
using static System.Reflection.Metadata.BlobBuilder;

namespace CarRental.Test
{
    public class ElectricCarServiceTest
    {
        [Fact]
        public async Task GetElectricCarListTest()
        {
            //Arrange
            Mock<ICarsRepository> _carsRepository = new Mock<ICarsRepository>();
            Mock<IMongoDbCacheRepository> _cacheRepository = new Mock<IMongoDbCacheRepository>();

            List<ElectricCar> evList = new List<ElectricCar>();
            ElectricCar ev1 = new ElectricCar
            {
                Id = 15,
                Brand = "Audi",
                Model = "E-tron",
                RentPrice = 15.99M,
                BatteryCapacity = "150kWh",
                BatteryChargingTime = 10
            };

            ElectricCar ev2 = new ElectricCar
            {
                Id = 15,
                Brand = "Audi",
                Model = "E-tron",
                RentPrice = 15.99M,
                BatteryCapacity = "150kWh",
                BatteryChargingTime = 10
            };

            ElectricCar ev3 = new ElectricCar
            {
                Id = 15,
                Brand = "Audi",
                Model = "E-tron",
                RentPrice = 15.99M,
                BatteryCapacity = "150kWh",
                BatteryChargingTime = 10
            };
            evList.Add(ev1);
            evList.Add(ev2);
            evList.Add(ev3);

            _carsRepository.Setup(x => x.GetAllElectricCars().Result).Returns(evList);
            _carsRepository.Setup(x => x.GetElectricCarCountFromDb().Result).Returns(evList.Count);
            _cacheRepository.Setup(x => x.GetElectricCarCount().Result).Returns(0);
            ICarsService carsService = new CarsService(_carsRepository.Object, _cacheRepository.Object);


            //Act
            var evTestList = await carsService.GetAllElectricCars();
            //Assert
            Assert.Equal(evList.Count, evTestList.Count);

        }
    }
}