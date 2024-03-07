using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MilesCarRental.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Identification { get; set; }

        public string Phone { get; set; }
        
        [JsonIgnore]
        public ICollection<CarRental> Rentals { get; set; }
    }
}
