using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MilesCarRental.Models
{
    public class Location
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        [JsonIgnore]
        public ICollection<CarRental>? PickupLocation { get; set; }
        
        [JsonIgnore]
        public ICollection<CarRental>? ReturnLocation { get; set; }
        
        [JsonIgnore]
        public ICollection<Car>? Cars { get; set; }
    }
}
