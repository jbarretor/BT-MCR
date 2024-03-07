using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MilesCarRental.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Year { get; set; }

        public bool IsAvailable { get; set; }

        public int LocationId { get; set; }
        
        [JsonIgnore]
        public Location? Location { get; set; }
        
        [JsonIgnore]
        public ICollection<CarRental>? Rentals { get; set; }
    }
}
