using ManiaGaming.Models.Data;
using System.Collections.Generic;

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
