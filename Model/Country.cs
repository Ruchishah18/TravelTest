namespace DataAccess.Model
{
    public class Country
    {
        public int GeographyLevel1Id { get; set; }
        public string Name { get; set; }
        public List<Airport> Airports { get; set; }
    }
}
