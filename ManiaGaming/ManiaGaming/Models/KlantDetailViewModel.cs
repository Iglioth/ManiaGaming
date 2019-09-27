using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class KlantDetailViewModel
    {
        public int KlantId { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public DateTime Geboortedatum { get; set; }
        public int Punten { get; set; }
    }
}
