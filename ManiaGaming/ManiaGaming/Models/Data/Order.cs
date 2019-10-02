using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Datum { get; set; }
        public int ProductNummer { get; set; }
        public string ProductNaam { get; set; }
        public int Aantal { get; set; }
    }
}
