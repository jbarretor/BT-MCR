using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MilesCarRental.Models
{
    public class CarRental
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int CarId { get; set; }

        public int PickupLocationId { get; set; }

        public int ReturnLocationId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        [JsonIgnore]
        public Client Client { get; set; }
        
        [JsonIgnore]
        public Location PickupLocation { get; set; }
        
        [JsonIgnore]
        public Location ReturnLocation { get; set; }
        
        [JsonIgnore]
        public Car Car { get; set; }
    }
}
