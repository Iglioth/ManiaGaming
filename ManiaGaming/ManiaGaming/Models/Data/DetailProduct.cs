using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class DetailProduct
    {
        int DetailProductId { get; set; }
        int ProductId { get; set; }
        int FiliaalId { get; set; }
        bool Retour { get; set; }
        bool Verkocht { get; set; }
    }
}
