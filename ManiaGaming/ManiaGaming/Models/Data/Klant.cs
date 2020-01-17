using System;

namespace ManiaGaming.Models.Data
{
    public class Klant : Account
    {
        public long KlantId { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public DateTime Geboortedatum { get; set; }
        public int Punten { get; set; }
    }
}
