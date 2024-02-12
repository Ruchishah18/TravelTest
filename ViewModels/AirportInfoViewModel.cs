namespace IntuitiveTest.ViewModels
{
    public class AirportInfoViewModel
    {
        public int Id { get; set; }
        public string IATACode { get; set; }
        public int CountryId { get; set; }
        public string Type { get; set; }

        public CountryViewModel CountryViewModel { get; set; }
    }
}
