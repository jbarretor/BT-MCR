using DataAccess.DbConection.DbConection;
using MilesCarRental.Business.Interfaces;
using MilesCarRental.Models;

namespace MilesCarRental.Business.Implementations
{
    public class CarRentalBusiness : ICarRentalBusiness
    {
        private readonly ApplicationDbContext _dbConection;

        public CarRentalBusiness(ApplicationDbContext dbConection)
        {
            _dbConection = dbConection;
        }

        public int NewCarRental(Client client, CarRental carRental)
        {
            var car = _dbConection.Cars.FirstOrDefault(x => x.Id == carRental.CarId);

            if (car == null)
            {
                return -1;
            }

            var pickupLocation = _dbConection.Locations.FirstOrDefault(x => x.Id == carRental.PickupLocationId);

            if (pickupLocation == null)
            {
                return -2;
            }

            var returnLocation = _dbConection.Locations.FirstOrDefault(x => x.Id == carRental.ReturnLocationId);

            if (returnLocation == null)
            {
                return -3;
            }

            var clientDB = _dbConection.Clients.FirstOrDefault(x => x.Identification == client.Identification);

            if (clientDB == null)
            {
                _dbConection.Clients.Add(client);
                _dbConection.SaveChanges();
                clientDB = client;
            }

            carRental.ClientId = clientDB.Id;
            var result = _dbConection.CarRentals.Add(carRental);
            _dbConection.SaveChanges();

            return (int)result.State;
        }
    }
}
