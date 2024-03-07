using MilesCarRental.Models;

namespace MilesCarRental.Business.Interfaces
{
    public interface ICarBusiness
    {
        public List<Car> getCarsByLocation(int locationId);

        public int addCar(Car location);
    }
}
