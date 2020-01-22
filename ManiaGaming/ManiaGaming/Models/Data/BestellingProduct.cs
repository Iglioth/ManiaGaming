using System;

namespace ManiaGaming.Models.Data
{
    public class BestellingProduct : Product
    {
        public int BestellingId { get; set; }
        public DateTime Datum { get; set; }
        public int KlantID { get; set; }
        public bool BestellingActief { get; set; }
    }
}
