using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int werknemerID { get; set; }
        public int filiaalID { get; set; }
        public bool Ontvangen { get; set; }
        public List<Filiaal> filialen { get; set; }
        public List<Product> producten { get; set; }
        public int ProductId { get; set; }
        public int aantal { get; set; }
    }
}
