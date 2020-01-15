using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class WerknemerViewModel : ZoekViewModel
    {
        public List<WerknemerDetailViewModel> WerknemerDetailViewModels { get; set; }

        public List<FiliaalDetailViewModel> FiliaalList { get; set; }
    }
}
