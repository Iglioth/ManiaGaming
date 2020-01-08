using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class WerknemerDetailViewModel : AccountDetailViewModel
    {
        public int WerknemerId { get; set; }
        public int FiliaalId { get; set; }
        public string FiliaalLocatie { get; set; }
        public List<Filiaal> FiliaalList { get; set; }
    }
}
