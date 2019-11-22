using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class WinkelwagenDetailViewModel
    {
        public int WinkelWagenId { get; set; }
        public int TotalPrijs { get; set; }
        public List<Product> producten = new List<Product>();
        public Account account = new Account();
    }
}
