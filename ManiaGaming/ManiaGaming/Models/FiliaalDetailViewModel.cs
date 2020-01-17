namespace ManiaGaming.Models
{
    public class FiliaalDetailViewModel : ZoekViewModel
    {
        public int Id { get; set; }
        public string Stad { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public string Telefoonnummer { get; set; }
        public bool Actief { get; set; }
    }
}
