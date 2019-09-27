using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Bestelling
    {
        public int BestellingId { get; set; }
        public DateTime Datum { get; set; }
        public int BestelNummer { get; set; }
        public int Aantal { get; set; }
    }
}
