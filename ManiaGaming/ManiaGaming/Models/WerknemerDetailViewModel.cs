using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class WerknemerDetailViewModel : AccountDetailViewModel
    {
        public int WerknemerId { get; set; }
        public string functie { get; set; }
    }
}
