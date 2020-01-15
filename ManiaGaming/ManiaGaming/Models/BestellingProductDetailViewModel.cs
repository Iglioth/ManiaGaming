using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class BestellingProductDetailViewModel : ProductDetailViewModel
    {
        public int BestellingId { get; set; }
        public DateTime Datum { get; set; }
        public int KlantID { get; set; }
        public bool BestellingActief { get; set; }
    }
}
