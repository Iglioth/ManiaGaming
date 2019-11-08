using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Filiaal
    {
        public int FiliaalId { get; set; }
        public string stad { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public string Telefoonnummer { get; set; }
        public bool Actief { get; set; }
    }
}
