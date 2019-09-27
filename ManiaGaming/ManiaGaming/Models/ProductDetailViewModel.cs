using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class ProductDetailViewModel
    {
        public int ProductID { get; set; }
        public string Soort { get; set; }
        public string Omschrijving { get; set; }
        public string Naam { get; set; }
        public int Aantal { get; set; }
        public string Prijs { get; set; }
    }
}
