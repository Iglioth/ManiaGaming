using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Bestelling
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int KlantID { get; set; }
        public bool Actief { get; set; }
    }
}
