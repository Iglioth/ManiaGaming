using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int WerknemerID { get; set; }
        public int FiliaalID { get; set; }
        public bool Ontvangen { get; set; }
        public List<Filiaal> Filialen { get; set; }
        public List<Product> Producten { get; set; }
        public int Aantal { get; set; }
        public int ProductID { get; set; }

        public Order(int id, DateTime datum, int werknermerid, int filiaalid, bool ontvangen)
        {
            this.Id = id;
            this.Datum = datum;
            this.WerknemerID = werknermerid;
            this.FiliaalID = filiaalid;
            this.Ontvangen = ontvangen;
        } 

        public Order()
        {

        }


    }
}
