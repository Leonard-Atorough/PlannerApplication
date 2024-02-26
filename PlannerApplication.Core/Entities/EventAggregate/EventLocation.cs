
namespace PlannerApplication.Core.Entities.EventAggregate
{
    public class EventLocation // Value object - see obsidian note 051
    {
        public string AddressLine1 { get; init; }
        public string AddressLine2 { get; init;}
        public string City { get; init; }
        public string Region { get; init; }
        public string PostalCode { get; init; }
        public string Country { get; init; }

        public EventLocation(string addressLine1, string addressLine2, string city, string region, string postalCode, string country)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
        }

#pragma warning disable //required by EF Core
        private EventLocation() {}
    }
}