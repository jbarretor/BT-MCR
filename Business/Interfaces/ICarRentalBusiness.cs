using MilesCarRental.Models;

namespace MilesCarRental.Business.Interfaces
{
    public interface ICarRentalBusiness
    {
        public int NewCarRental(Client client, CarRental carRental);

    }
}
