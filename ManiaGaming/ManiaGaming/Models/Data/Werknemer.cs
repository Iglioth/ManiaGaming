namespace ManiaGaming.Models.Data
{
    public class Werknemer : Account
    {
        public int WerknemerId { get; set; }
        public string Functie { get; set; }
        public int FiliaalID { get; set; }
        public string FiliaalId { get; internal set; }
        public string FiliaalNaam { get; set; }
    }
}
