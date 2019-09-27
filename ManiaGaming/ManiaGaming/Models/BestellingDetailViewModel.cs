using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class BestellingDetailViewModel
    {
        public int BestellingId { get; set; }
        public DateTime Datum { get; set; }
        public int BestelNummer { get; set; }
        public int Aantal { get; set; }
    }
}   
