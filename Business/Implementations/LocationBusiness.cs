using DataAccess.DbConection.DbConection;
using Microsoft.EntityFrameworkCore;
using MilesCarRental.Business.Interfaces;
using MilesCarRental.Models;

namespace MilesCarRental.Business.Implementations
{
    public class LocationBusiness : ILocationBusiness
    {
        private readonly ApplicationDbContext _dbConection;

        public LocationBusiness(ApplicationDbContext dbConection)
        {
            _dbConection = dbConection;
        }

        public List<Location> getLocation()
        {
            return _dbConection.Locations.ToListAsync().Result;
        }

        public Location getInfoByNameAndAddress(string name, string address)
        {
            return _dbConection.Locations
                .FirstOrDefault(x => x.Name == name && x.Address == address);
        }

        public Location getInfoByLocationId(int id)
        {
            return _dbConection.Locations
                .FirstOrDefault(x => x.Id == id);
        }

        public int addLocation(Location location)
        {
            var x = _dbConection.Locations.AddAsync(location).Result;
            _dbConection.SaveChanges();

            return (int)x.State;
        }
    }
}
