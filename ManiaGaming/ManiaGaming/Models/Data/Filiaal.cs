using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Filiaal
    {
        public int Id { get; set; }
        public string Stad { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public string Telefoonnummer { get; set; }
        public bool Actief { get; set; }
    }
}
