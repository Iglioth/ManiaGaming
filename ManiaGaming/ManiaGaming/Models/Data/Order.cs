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
        public int WerknemerID { get; set; }
        public int FiliaalID { get; set; }
        public bool Ontvangen { get; set; }
    }
}
