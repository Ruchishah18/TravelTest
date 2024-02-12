using DataAccess.Model.Enum;

namespace DataAccess.Model
{
    public class Airport
    {
        public int AirportId { get; set; }
        public string IATACode { get; set; }
        public int GeographyLevel1Id { get; set; }
        public AirportType Type { get; set; }
        public Country Country { get; set; }
        public List<AirportGroup> AirportGroups { get; set; }

    }
}
