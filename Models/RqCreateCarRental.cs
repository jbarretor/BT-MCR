namespace MilesCarRental.Models
{
    public class RqCreateCarRental
    {
        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string ClientIdentification { get; set; }

        public string ClientPhone { get; set; }

        public int VehicleId { get; set; }

        public int PickupLocationId { get; set; }

        public int ReturnLocationId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
