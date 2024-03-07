using DataAccess.DbConection.DbConection;
using MilesCarRental.Business.Interfaces;
using MilesCarRental.Models;

namespace MilesCarRental.Business.Implementations
{
    public class CarBusiness : ICarBusiness
    {
        private readonly ApplicationDbContext _dbConection;

        public CarBusiness(ApplicationDbContext dbConection)
        {
            _dbConection = dbConection;
        }

        public List<Car> getCarsByLocation(int locationId)
        {
            return _dbConection.Cars.Where(x => x.LocationId == locationId).ToList();
        }

        public int addCar(Car input)
        {
            var car = _dbConection.Cars.Add(input);
            _dbConection.SaveChanges();

            return (int)car.State;
        }
    }
}
