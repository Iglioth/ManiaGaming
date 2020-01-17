using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;

namespace ManiaGaming.Models
{
    public class OrderDetailViewModel : ZoekViewModel
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int WerknemerID { get; set; }
        public int FiliaalID { get; set; }
        public bool Ontvangen { get; set; }
        public List<Filiaal> Filialen { get; set; }
        public List<Product> Producten { get; set; }
        public int ProductId { get; set; }
        public int Aantal { get; set; }
    }
}
