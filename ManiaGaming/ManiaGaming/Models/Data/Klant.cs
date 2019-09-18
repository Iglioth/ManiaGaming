using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Klant : Account
    {
        public long Id { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public DateTime Geboortedatum { get; set; }
    }
}
