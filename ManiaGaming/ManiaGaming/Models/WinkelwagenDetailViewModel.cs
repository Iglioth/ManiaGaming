using ManiaGaming.Models.Data;
using System.Collections.Generic;

namespace ManiaGaming.Models
{
    public class WinkelwagenDetailViewModel : ZoekViewModel
    {
        public int WinkelWagenId { get; set; }
        public int TotalPrijs { get; set; }
        public List<Product> producten = new List<Product>();
        public Account account = new Account();
    }
}
