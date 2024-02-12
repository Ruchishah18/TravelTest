namespace DataAccess.Model
{
    public class AirportGroup
    {
        public int AirportGroupId { get; set; }
        public string Name { get; set; }
        public List<Airport> Airports { get; set; }
    }
}
