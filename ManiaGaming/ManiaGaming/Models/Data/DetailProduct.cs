using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class DetailProduct
    {
        public int DetailProductId { get; set; }
        public int ProductId { get; set; }
        public int FiliaalId { get; set; }
        public bool Retour { get; set; }
        public bool Verkocht { get; set; }
    }
}
