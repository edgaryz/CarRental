using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Repositories
{
    public class CarsDbRepository : ICarsRepository
    {
        private readonly string _dbConnectionString;
        public CarsDbRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }
        public void WriteCars(List<Car> carList)
        {
            throw new NotImplementedException();
        }

        public List<Car> ReadCars()
        {
            throw new NotImplementedException();
        }
    }
}
