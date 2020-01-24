using ManiaGaming.Models.Data;
using System.Collections.Generic;

namespace ManiaGaming.Models
{
    public class WinkelwagenDetailViewModel : ZoekViewModel
    {
        public int WinkelWagenId { get; set; }
        public decimal TotaalPrijs { get; set; }
        public List<Product> producten = new List<Product>();
        public Account account = new Account();
        public int klantPunten { get; set; }
        public int KostenInPunten { get; set; }
        public int ResterendeBedrag { get; set; }

   
    }
}
