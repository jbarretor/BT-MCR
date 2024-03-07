using MilesCarRental.Models;

namespace MilesCarRental.Business.Interfaces
{
    public interface ILocationBusiness
    {

        public List<Location> getLocation();

        public int addLocation(Location location);

        public Location getInfoByNameAndAddress(string name, string address);

        public Location getInfoByLocationId(int id);
    }
}
