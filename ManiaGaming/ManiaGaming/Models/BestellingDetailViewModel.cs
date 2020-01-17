using System;

namespace ManiaGaming.Models
{
    public class BestellingDetailViewModel : ZoekViewModel
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int KlantID { get; set; }
    }
}   
